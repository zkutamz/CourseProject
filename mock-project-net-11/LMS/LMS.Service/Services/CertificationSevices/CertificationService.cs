using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request;
using LMS.Model.Request.CertificateDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Model.Response.UserCertigicateDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using LMS.Service.Services.CourseService;
using LMS.Service.Services.HanleCertificateServices;
using LMS.Service.Services.QuizSubmissionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.CertificationSevices
{
    public class CertificationService : ICertificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CertificationService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICourseService _courseService;
        private readonly IHanleCertificateFilesServices _handleCertificateService;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly IQuizSubmissionServices _quizSubmissionServices;
        private readonly IUserAccessor _userAccessor;

        public CertificationService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CertificationService> logger,
            IUserAccessor userAccessor,
            UserManager<AppUser> userManager,
            ICourseService courseService,
            IHanleCertificateFilesServices handleCertificateService,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            IQuizSubmissionServices quizSubmissionServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _courseService = courseService;
            _handleCertificateService = handleCertificateService;
            _responseMessage = responseMessage.Value;
            _quizSubmissionServices = quizSubmissionServices;
            _userAccessor = userAccessor;
        }

        public async Task<bool> DeleteCertificateAsync(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var certificate = await _unitOfWork.CertificationRepository.GetAsync(s => s.Id == id);
                if (certificate == null)
                {
                    throw new NotFoundException(_responseMessage.NotFound);
                }
                certificate.IsDelete = true;
                var result = await _unitOfWork.CertificationRepository.UpdateAsync(certificate);
                if (result is false)
                    throw new BadRequestException(_responseMessage.UpdateFailure);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(DeleteCertificateAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<CertificateDetailDTO> GetCertificateDetailAsync(int id)
        {
            try
            {
                var certificate = await _unitOfWork.CertificationRepository.GetAsync(s => s.Id == id);
                if (certificate is null)
                    throw new NotFoundException(_responseMessage.NotFound);
                return _mapper.Map<Certificate, CertificateDetailDTO>(certificate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetCertificateDetailAsync));
                throw;
            }
        }
        public async Task<PaginatedList<CertificateDTO>> SearchAsync(string keyword, PagingRequest pagingRequest)
        {
            try
            {
                var courseCommentDTO = await _unitOfWork.CertificationRepository
                    .SearchAsync(keyword, pagingRequest);
                if (courseCommentDTO.Count == 0)
                {
                    throw new NotFoundException(_responseMessage.NotFound);
                }
                return _mapper.Map<PaginatedList<Certificate>, PaginatedList<CertificateDTO>>(courseCommentDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task<bool> CreateCertificateAsync(CertificateCreateDTO certificateCreateDTO)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var certificate = _mapper.Map<CertificateCreateDTO, Certificate>(certificateCreateDTO);
                var addResult = await _unitOfWork.CertificationRepository.AddAsync(certificate);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!addResult || saveResult == 0)
                {
                    throw new ConflictException(_responseMessage.AddFailure);
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateCertificateAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> EditCertificateAsync(CertificateEditDTO certificateEditDTO)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var certificate = _mapper.Map<CertificateCreateDTO, Certificate>(certificateEditDTO);
                var updateResult = await _unitOfWork.CertificationRepository.UpdateAsync(certificate);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                {
                    throw new ConflictException(_responseMessage.UpdateFailure);
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(EditCertificateAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> HardDeleteCertificateAsync(int certificateId)
        {
            var existedCertificate = await _unitOfWork.CertificationRepository.GetAsync(x => x.Id == certificateId);
            if (existedCertificate == null)
            {
                throw new NotFoundException(_responseMessage.NotFound);
            }
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var removeResult = await _unitOfWork.CertificationRepository.RemoveAsync(existedCertificate);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!removeResult || saveResult == 0)
                {
                    throw new ConflictException(_responseMessage.DeleteFailure);
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteCertificateAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<PaginatedList<CertificateDTO>> FilterByCategoryAsync(int certificateCategoryId)
        {
            var pagingRequest = new PagingRequest();
            var certificates = await _unitOfWork.CertificationRepository
                .GetAllAsync(pagingRequest, x => x.CertificateCategoryId == certificateCategoryId);
            if (certificates.Count == 0)
                throw new NotFoundException(_responseMessage.NotFound);
            var certificateDto = _mapper.Map<PaginatedList<CertificateDTO>>(certificates);
            return certificateDto;
        }
        public async Task<PagingResult<MyCertificateModel>> GetCertificatesDetailOfUserAsync(PagingRequest pagingRequest)
        {
            try
            {
                var userId = await _userAccessor.GetUserId();
                var currentUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.Id == userId);
                if (currentUser == null)
                    throw new UnauthorizedAccessException(_responseMessage.AccessDenied);
                var certificates = await _unitOfWork.CertificationRepository
                    .GetCertificateResultOfCurrentUser(pagingRequest, currentUser.Id);
                if (certificates.Count == 0)
                    throw new NotFoundException();

                List<MyCertificateModel> listCertificate = new List<MyCertificateModel>();
                foreach (var certificate in certificates)
                {
                    var certificateResultDetail = (_unitOfWork.CertificationRepository
                        .GetCertificateResultSubmition(certificate.Id, currentUser.Id)
                        .FirstOrDefault());
                    var userCertificate = await _unitOfWork.CertificationRepository
                        .GetUserCertificate(currentUser.Id, certificate.Id);
                    var myCertificateResult = new MyCertificateModel()
                    {
                        ItemNo = certificate.Id,
                        Titile = certificate.CertificateName,
                        Mark = certificateResultDetail.CorectAnswers,
                        OutOf = certificateResultDetail.TotalQuestion,
                        CertificateImageUrl = userCertificate.ImageCertificateUrl,
                        UpLoadDate = userCertificate.CreatedAt
                    };
                    listCertificate.Add(myCertificateResult);
                }
                var result = new PagingResult<MyCertificateModel>()
                {
                    TotalCount = certificates.TotalCount,
                    PageSize = certificates.PageSize,
                    CurrentPage = certificates.CurrentPage,
                    TotalPages = certificates.TotalPages,
                    Objects = listCertificate
                };
                return result;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                _logger.LogError(exception.Message);
                throw;
            }
        }
        public async Task<PagingResult<QuizQuestionDTO>> GetQuizzQuestionForCertificateTestAsync(PagingRequest pagingRequest, int certificateId, int numberOfQuestion)
        {
            var paginatedListQuizzQuestion = await _unitOfWork.CertificationRepository
                .GetQuizzForCertificateTestAsync(pagingRequest, certificateId, numberOfQuestion);
            if (paginatedListQuizzQuestion.Count == 0)
                throw new NotFoundException(_responseMessage.NotFound);
            var quizzQuestionDto = _mapper.Map<PaginatedList<QuizQuestionDTO>>(paginatedListQuizzQuestion);
            var paginatedQuizzQuestionResult = new PagingResult<QuizQuestionDTO>()
            {
                PageSize = quizzQuestionDto.PageSize,
                TotalPages = quizzQuestionDto.TotalPages,
                CurrentPage = quizzQuestionDto.CurrentPage,
                TotalCount = quizzQuestionDto.TotalCount,
                Objects = quizzQuestionDto
            };
            return paginatedQuizzQuestionResult;
        }

        public async Task<AssignToCertificateResult> AssignCertificateToUseAsync(AppUser user, Certificate certificate)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var newUserCertificate = new UserCertificate()
                {
                    UserId = user.Id,
                    CertificateId = certificate.Id,
                };
                var existedUserCertificate = await _unitOfWork.UserCertificateRepository
                    .GetAsync(x => x.UserId == newUserCertificate.UserId
                    && x.CertificateId == newUserCertificate.CertificateId);
                if (existedUserCertificate != null)
                {
                    return new AssignToCertificateResult() 
                    { 
                        IsCertificated=true,
                        Message=_responseMessage.CertificateAlreadyExist
                    };
                }
                newUserCertificate.ImageCertificateUrl = await _handleCertificateService
                    .HandleCertificateImageAsync(user, certificate);
                var createResult = await _unitOfWork.UserCertificateRepository.AddAsync(newUserCertificate);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!createResult || saveResult == 0)
                {
                    await _handleCertificateService.DeleteFileAsync(newUserCertificate.ImageCertificateUrl);
                    return new AssignToCertificateResult()
                    {
                        IsCertificated = false,
                        Message=_responseMessage.AddFailure
                    };
                }
                await transaction.CommitAsync();
                return new AssignToCertificateResult() 
                {
                    IsCertificated=true,
                    Message=_responseMessage.AddSuccess
                };
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                _logger.LogError(exception.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<QuizzCertificateResultDTO> ProcessingResultAndCertificationAsync(UserAnswersDTO userAnswersDTO)
        {
            try
            {
                var quizResult = await _quizSubmissionServices.HandleQuizResult(userAnswersDTO);
                //var quizResult = new QuizSubmissionDTO();
                //quizResult.IsCompleted = true;
                //quizResult.IsPassed = true;
                //quizResult.TotalQuestion = 20;
                //quizResult.CorectAnswers = 15;
                //quizResult.WrongAnswers = 5;
                //quizResult.UserId = 3;
                //quizResult.QuizId = 2;
                var quizCertificateResult = new QuizzCertificateResultDTO()
                {
                    QuizSubmission = quizResult
                };
                var currenUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.Id == quizResult.UserId);
                if (currenUser == null)
                    throw new BadRequestException(_responseMessage.LoginFailure);
                var certificate = await _unitOfWork.QuizzCertificateRepository.GetCertificateByQuizIdAsync((int)quizResult.QuizId);
                if (certificate == null)
                {
                    throw new NotFoundException(_responseMessage.NotFound);
                }
                if (quizResult.IsPassed)
                {
                    var assignResult = await AssignCertificateToUseAsync(currenUser, certificate);
                    quizCertificateResult.AssignToCertificateResult = assignResult;
                }
                return quizCertificateResult;
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                _logger.LogError(exeption.Message);
                throw;
            }
        }

        public async Task<bool> CheckAndAssignCertificateForCompletedCourseAsync(int userId, int courseId)
        {
            var currentUserId = await _userAccessor.GetUserId();
            if (currentUserId != userId)
            {
                throw new BadRequestException(_responseMessage.LoginFailure);
            }
            var totalLession = await _unitOfWork.CourseRepository.GetTotalLessonOfCourse(courseId);
            var totalLessionCompleted =await _unitOfWork.CourseRepository.GetTotalLessonCompletedOfUser(userId, courseId);
            if(totalLession != totalLessionCompleted)
            {
                return false;
            }
            var currentUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.Id == currentUserId);
            var courseCertificate = await _unitOfWork.CertificationRepository.GetAsync(x => x.Id == courseId);
            if (courseCertificate == null)
            {
                throw new NotFoundException(_responseMessage.NotFound);
            }
            var existedCertificate = await _unitOfWork.UserCertificateRepository.GetAsync(x => x.UserId == currentUser.Id && x.CertificateId == courseCertificate.Id&& x.IsDelete==false);
            if (existedCertificate != null)
            {
                return true;
            }
            var assignResult = await AssignCertificateToUseAsync(currentUser, courseCertificate);
            if (!assignResult.IsCertificated)
                throw new ConflictException(assignResult.Message);
            return assignResult.IsCertificated;
        }

    }



}

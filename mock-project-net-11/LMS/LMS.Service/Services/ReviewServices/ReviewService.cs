using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.ReviewDTOs;
using LMS.Model.Response.ReviewDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReviewService> _logger;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly ResponseMessageOptions _responseMessage;

        public ReviewService(IUnitOfWork unitOfWork,
            ILogger<ReviewService> logger,
            IMapper mapper,
            IUserAccessor userAccessor,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _responseMessage = responseMessage.Value;
        }
        #region Insert, Update, Delete
        public async Task<ReviewDTO> CreateReviewAsync(ReviewCreateDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var userId = await _userAccessor.GetUserId();

                var courseIsNotExist = !await _unitOfWork.CourseRepository
                        .ExistsAsync(
                        c => c.Id == request.CourseId);

                if (courseIsNotExist)
                    throw new NotFoundException(_responseMessage.CourseNotFound);

                var enrollCourse =
                    await _unitOfWork.EnrollCourseRepository
                    .GetAsync(
                        ec => ec.StudentId == userId && ec.CourseId == request.CourseId);

                if (enrollCourse is null) throw new NotFoundException(_responseMessage.EnrollCourseNotFound);

                var review = _mapper.Map<Review>(request);

                review.EnrollCourseId = enrollCourse.Id;

                var result = await _unitOfWork.ReviewRepository.AddAsync(review);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }

                return _mapper.Map<ReviewDTO>(review);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateReviewAsync));
                throw;
            }
        }

        public async Task<bool> UpdateReviewAsync(int id, ReviewEditDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id) throw new BadRequestException(_responseMessage.InvalidParameters);

                var review = await _unitOfWork.ReviewRepository.GetAsync(r => r.Id == id);

                if (review is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                _mapper.Map(request, review);

                var result = await _unitOfWork.ReviewRepository.UpdateAsync(review);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(UpdateReviewAsync));
                throw;
            }
        }

        public async Task<bool> UpdateTheHelpfulnessOfAnReviewAsync(int reviewId, bool isHelpful)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var result = false;
                var voteResult = false;

                if (reviewId <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var review = await _unitOfWork.ReviewRepository.GetAsync(r => r.Id == reviewId);

                if (review is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                var userId = await _userAccessor.GetUserId();

                var userVotesReview = await _unitOfWork.UserVotesReviewRepository
                    .GetAsync(u =>
                        u.UserId == userId && u.ReviewId == reviewId);

                if (userVotesReview is null)
                {
                    voteResult = await _unitOfWork.UserVotesReviewRepository.AddAsync(new UserVotesReview
                    {
                        UserId = userId,
                        ReviewId = reviewId,
                        IsHelpful = isHelpful
                    });

                    if (voteResult)
                    {
                        review.HelpfulnessRating = isHelpful ? review.HelpfulnessRating + 1 : review.HelpfulnessRating - 1;

                        result = await _unitOfWork.ReviewRepository.UpdateAsync(review);
                    }
                }
                else
                {
                    if (userVotesReview.IsHelpful)
                    {
                        if (isHelpful is false)
                        {
                            review.HelpfulnessRating -= 1;
                            userVotesReview.IsHelpful = !userVotesReview.IsHelpful;

                            result = await _unitOfWork.ReviewRepository.UpdateAsync(review);
                            voteResult = await _unitOfWork.UserVotesReviewRepository.UpdateAsync(userVotesReview);
                        }
                    }
                    else if (userVotesReview.IsHelpful is false)
                    {
                        if (isHelpful)
                        {
                            review.HelpfulnessRating += 1;

                            userVotesReview.IsHelpful = !userVotesReview.IsHelpful;

                            result = await _unitOfWork.ReviewRepository.UpdateAsync(review);
                            voteResult = await _unitOfWork.UserVotesReviewRepository.UpdateAsync(userVotesReview);
                        }
                    }
                }

                if (result && voteResult)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    _logger.LogInformation(_responseMessage.UpdateSuccess);
                    return true;
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(UpdateTheHelpfulnessOfAnReviewAsync));
                throw;
            }

            return false;
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var review = _mapper.Map<Review>(await _unitOfWork.ReviewRepository.GetReviewById(id));

                review.IsDelete = true;

                var result = await _unitOfWork.ReviewRepository.UpdateAsync(review);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    _logger.LogInformation("Delete Review Success");
                }

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Delete Review failed in service", nameof(DeleteReviewAsync));
                throw;
            }
        }
        #endregion

        #region Review course of Instructor
        #region Get Review

        public async Task<List<ReviewDetailDTO>> GetAllReviewDetailDTOForInstruoctorAsync(int instructorId, PagingRequest request)
        {
            try
            {
                request ??= new PagingRequest();
                var reviews = _mapper.Map<PaginatedList<Review>, PaginatedList<ReviewDetailDTO>>(await _unitOfWork.ReviewRepository.GetReviewDetailForInstructorPaging(instructorId, request));
                return reviews;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReviewFeaturedDTO> GetAFeaturedReviewAsync(int courseId)
        {
            try
            {
                var reviews = await _unitOfWork.ReviewRepository.GetAllReviewDetailForCourseAsync(courseId);

                return _mapper.Map<ReviewFeaturedDTO>(
                    reviews.Aggregate(
                        (c1, c2) => c1.Rating < c2.Rating ? c2 : c1));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetAFeaturedReviewAsync));
                throw;
            }
        }

        #endregion
        #region Get Rating

        public async Task<double> GetAverageRatingCourseOfInstructorAsync(int idInstructor)
        {
            try
            {
                var rating = await _unitOfWork.ReviewRepository.GetAllReviewForInstructorAsync(idInstructor);
                
                return rating.Count == 0 ? 0 : rating.Average(r => r.Rating);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetAverageRatingCourseOfInstructorAsync));
                throw;
            }
        }

        public async Task<List<int>> GetRatinCourseOfInstructorgAsync(int idInstructor)
        {
            try
            {
                List<int> result = new List<int>() { 0, 0, 0, 0, 0 };
                var rating = await _unitOfWork.ReviewRepository.GetAllReviewForInstructorAsync(idInstructor);
                foreach (var item in rating)
                {
                    result[item.Rating - 1] += 1;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion 

        #endregion

        public async Task<PagingResult<ReviewDetailDTO>> SearchReviewAsync(string key, PagingRequest request = null)
        {
            try
            {
                request ??= new PagingRequest();
                var reviews = _mapper.Map<PaginatedList<Review>, PaginatedList<ReviewDetailDTO>>(await _unitOfWork.ReviewRepository.SearchReview(key, request));
                var pageResult = new PagingResult<ReviewDetailDTO>()
                {
                    TotalCount = reviews.TotalCount,
                    PageSize = reviews.PageSize,
                    TotalPages = reviews.TotalPages,
                    CurrentPage = reviews.CurrentPage,
                    Objects = reviews
                };
                return pageResult;


            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Review, Rating of Course

        public async Task<PagingResult<ReviewDetailDTO>> GetAllReviewDetailDTOForCourseAsync(int courseId, PagingRequest request = null)
        {
            try
            {
                request ??= new PagingRequest();

                var courseIsNotExist = !await _unitOfWork.CourseRepository
                        .ExistsAsync(
                        c => c.Id == courseId);

                if (courseIsNotExist)
                    throw new NotFoundException(_responseMessage.CourseNotFound);

                var reviews = await _unitOfWork.ReviewRepository.GetAllReviewForCourseDetailAsync(courseId, request);

                var reviewDTOs = _mapper.Map<PaginatedList<Review>, PaginatedList<ReviewDetailDTO>>(reviews);

                var pageResult = new PagingResult<ReviewDetailDTO>()
                {
                    TotalCount = reviews.TotalCount,
                    PageSize = reviews.PageSize,
                    TotalPages = reviews.TotalPages,
                    CurrentPage = reviews.CurrentPage,
                    Objects = reviewDTOs
                };

                return pageResult;


            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Rating

        public async Task<double> GetAverageRatingCourseAsync(int courseId)
        {
            try
            {
                var rating = await _unitOfWork.ReviewRepository.GetAllReviewForCourseAsync(courseId);

                return rating.Count == 0 ? 0 : rating.Average(r => r.Rating);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetAverageRatingCourseAsync));
                throw;
            }
        }

        public async Task<List<int>> GetRatingCourseAsync(int courseId)
        {
            try
            {
                List<int> result = new List<int>() { 0, 0, 0, 0, 0 };
                var rating = await _unitOfWork.ReviewRepository.GetAllReviewForCourseAsync(courseId);
                foreach (var item in rating)
                {
                    result[item.Rating - 1] += 1;
                }
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetRatingCourseAsync));

                throw;
            }
        }

        public async Task<List<ReviewDetailDTO>> GetLatestReviews()
        {
            try
            {
                var reviewDTO = await _unitOfWork.ReviewRepository.GetLatestReviews();

                return _mapper.Map<List<ReviewDetailDTO>>(reviewDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        #endregion
        #endregion
    }
}
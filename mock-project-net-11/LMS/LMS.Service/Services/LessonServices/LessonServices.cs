using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.LessonDTOs;
using LMS.Model.Response.Lessons;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.AttachmentServices;
using LMS.Service.Services.FileStorageServices;
using LMS.Service.Services.SectionServices;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.LessonServices
{
    public class LessonServices : ILessonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<LessonServices> _logger;
        private readonly IFileStorageService _fileStorageService;
        private readonly ISectionService _sectionService;
        private readonly IAttachmentService _attachmentService;
        private const string USER_CONTENT_FOLDER_NAME = "storage-upload";
        public LessonServices(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<LessonServices> logger,
            IFileStorageService fileStorageService,
            ISectionService sectionService,
            IAttachmentService attachmentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _fileStorageService = fileStorageService;
            _sectionService = sectionService;
            _attachmentService = attachmentService;
        }
        /// <summary>
        /// Create lesson
        /// </summary>
        /// <param name="request"></param>
        /// <returns>LessonDTO</returns>
        public async Task<LessonDTO> CreateLessonAsync(LessonCreateDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var lesson = _mapper.Map<LessonCreateDTO, Lesson>(request);
                
                var result = await _unitOfWork.LessonRepository.AddAsync(lesson);
                
                if (!result)
                {
                    throw new BadRequestException();
                }

                await _unitOfWork.SaveAsync();
                await _sectionService.UpdateSectionTotalTimeAsync(request.SectionId, request.TotalTime);
                await transaction.CommitAsync();

                var lessonDTO = _mapper.Map<Lesson, LessonDTO>(lesson);

                return lessonDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(CreateLessonAsync));

                await transaction.RollbackAsync();
                await transaction.DisposeAsync();

                throw;
            }
        }


        public async Task<bool> DeleteLessonAsync(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.LessonRepository.GetAsync(s => s.Id == id);
                if (user == null)
                {
                    throw new NotFoundException();
                }
                user.IsDelete = true;
                var result = await _unitOfWork.LessonRepository.UpdateAsync(user);
                if (result is false)
                    throw new BadRequestException();
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(DeleteLessonAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<LessonDTO>> GetLessonAsync(PagingRequest request)
        {
            try
            {
                request ??= new PagingRequest();

                var lessons = await _unitOfWork.LessonRepository.GetAllAsync(request,x=>x.Id ==x.Id,x => x.Attachments);

                if (lessons is null)
                    throw new NotFoundException();

                var lessonDTOs = _mapper.Map<PaginatedList<Lesson>, PaginatedList<LessonDTO>>(lessons);

                if (lessonDTOs is null)
                    throw new BadRequestException();

                return new PagingResult<LessonDTO>()
                {
                    CurrentPage = lessonDTOs.CurrentPage,
                    TotalCount = lessonDTOs.TotalCount,
                    PageSize = lessonDTOs.PageSize,
                    TotalPages = lessonDTOs.TotalPages,
                    Objects = lessonDTOs
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetLessonAsync));
                throw;
            }
        }

        public async Task<LessonDTO> GetLessonDetailAsync(int id)
        {
            try
            {
                var lesson = await _unitOfWork.LessonRepository.GetAsync(s => s.Id == id, x=>x.Attachments);
                if (lesson is null)
                    throw new NotFoundException();
                return _mapper.Map<Lesson, LessonDTO>(lesson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetLessonDetailAsync));
                throw;
            }
        }

        public async Task<LessonEditDTO> UpdateLessonAsync(int id, LessonEditDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id)
                    throw new BadRequestException();
                var user = _mapper.Map<LessonEditDTO, Lesson>(request);
                if (user is null)
                    throw new BadRequestException();
                var result = await _unitOfWork.LessonRepository.UpdateAsync(user);
                if (!result)
                    throw new BadRequestException();
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return request;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateLessonAsync));
                throw;
            }

        }

        public async Task<PagingResult<LessonDTO>> GetLessonBySectionId(int sectionId, PagingRequest request)
        {
            try
            {
                var lessonBySectionIdPaginatedList = await _unitOfWork.LessonRepository.GetLessonBySectionId(sectionId, request);
                var lessonBySectionIdDto = _mapper.Map<PaginatedList<Lesson>, PaginatedList<LessonDTO>>(lessonBySectionIdPaginatedList);

                var pagingResult = new PagingResult<LessonDTO>()
                {
                    TotalPages = lessonBySectionIdPaginatedList.TotalPages,
                    TotalCount = lessonBySectionIdPaginatedList.TotalCount,
                    CurrentPage = lessonBySectionIdPaginatedList.CurrentPage,
                    PageSize = lessonBySectionIdPaginatedList.PageSize,
                    Objects = lessonBySectionIdDto
                };
                return pagingResult;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetLessonBySectionId));
                throw;
            }
        }
    }
}

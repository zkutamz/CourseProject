using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Response.CourseDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Enums;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CourseCommentDTO = LMS.Model.Response.CourseCommentDTOs.CourseCommentDTO;

namespace LMS.Service.Services.CourseManagementService
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CourseManagementService> _logger;
        private readonly IMapper _mapper;

        public CourseManagementService(IUnitOfWork unitOfWork, ILogger<CourseManagementService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CourseDTO>> GetAllPendingReview(PagingRequest pagingRequest)
        {
            var courses = await _unitOfWork.CourseRepository
                .GetAllAsync(pagingRequest, x => x.CourseStatus == CourseStatus.Pending);
            return _mapper.Map<PaginatedList<Course>, PaginatedList<CourseDTO>>(courses);
        }

        public async Task<PagingResult<CourseCommentDTO>> GetTotalCommentOnCourse(int courseId, PagingRequest pagingRequest)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {

                var courseCommentDTO = _mapper.Map<PaginatedList<CourseComment>, PaginatedList<CourseCommentDTO>>(await _unitOfWork.CourseCommentRepository
                    .GetTotalCommentOnCourse(courseId, pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<CourseCommentDTO>()
                {
                    TotalCount = courseCommentDTO.TotalCount,
                    PageSize = courseCommentDTO.PageSize,
                    TotalPages = courseCommentDTO.TotalPages,
                    CurrentPage = courseCommentDTO.CurrentPage,
                    Objects = courseCommentDTO
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PagingResult<CourseDTO>> SearchCourse(string keyword, PagingRequest pagingRequest)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {

                var courseDTO = _mapper.Map<PaginatedList<CourseDTO>>(await _unitOfWork.CourseRepository.SearchCourse
                    (keyword, pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<CourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task<PaginatedList<CourseCommentDTO>> GetTotalQACommentOnCourse(int courseId, PagingRequest pagingRequest)
        {
            try
            {
                var courseComment =
                    await _unitOfWork.CourseCommentRepository.GetTotalQACommentOnCourse(courseId, pagingRequest);
                if (courseComment is null)
                    throw new NotFoundException();
                return _mapper.Map<PaginatedList<CourseComment>, PaginatedList<CourseCommentDTO>>(courseComment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetTotalQACommentOnCourse));
                throw;
            }
        }

        /// <summary>
        /// Change course status to Active
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<bool> ActiveCourse(int courseId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var result = false;
                var course = await _unitOfWork.CourseRepository.GetAsync(n => (n.Id == courseId && n.CourseStatus != CourseStatus.Active && n.CourseStatus != CourseStatus.Draft));
                if(course == null) 
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                else
                {
                    course.CourseStatus = CourseStatus.Active;
                    await _unitOfWork.CourseRepository.UpdateAsync(course);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(ActiveCourse));
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

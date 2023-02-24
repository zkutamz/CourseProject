using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class CourseCommentRepository : Repository<CourseComment>, ICourseCommentRepository
    {
        public CourseCommentRepository(LMSApplicationContext context, ILogger<CourseCommentRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }

        public async Task<PaginatedList<CourseComment>> GetTotalCommentOnCourse(int courseId, PagingRequest pagingRequest)
        {
            try
            {
                var query = Context.CourseComment
                    .Include(x => x.Course)
                    .Where(x => x.CourseId == courseId);
                return await PaginatedList<CourseComment>.ToPaginatedListAsync(query,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetTotalCommentOnCourse));
                throw;
            }

        }
        public async Task<PaginatedList<CourseComment>> GetTotalQACommentOnCourse(int courseId, PagingRequest pagingRequest)
        {
            try
            {
                var comments = Context.CourseComment.Where(x => x.CourseId == courseId);
                return await PaginatedList<CourseComment>.ToPaginatedListAsync(comments,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
            }
            catch (Exception e) 
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetTotalQACommentOnCourse));
                throw;
            }
        }
    }
}

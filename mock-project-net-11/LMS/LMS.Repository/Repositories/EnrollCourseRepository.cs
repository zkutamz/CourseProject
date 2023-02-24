using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class EnrollCourseRepository : Repository<EnrollCourse>, IEnrollCourseRepository
    {

        public EnrollCourseRepository(LMSApplicationContext context, ILogger<EnrollCourseRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {

        }

        public async Task<PaginatedList<EnrollCourse>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest)
        {
            var data = Context.EnrollCourses
                .AsNoTracking()
                .AsQueryable()
                .Where(f => f.StudentId == studentId)
                .Include(x => x.Course)
                .ThenInclude(x => x.AppUser)
                .Include(y => y.Course).ThenInclude(y => y.Category);


            return await PaginatedList<EnrollCourse>.ToPaginatedListAsync(data,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }
    }
}

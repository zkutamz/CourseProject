using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IEnrollCourseRepository : IRepository<EnrollCourse>
    {
        Task<PaginatedList<EnrollCourse>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest);
    }
}

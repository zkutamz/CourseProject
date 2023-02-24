using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Repository.Entities;
using LMS.Repository.Paging;

namespace LMS.Repository.Interfaces
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetTeachByName(string userName);
        Task<int> GetTotalCoursePurchaseAsync(int userId);
        Task<int> GetTotalReviewsAsync(int userId);
        Task<int> GetTotalSubscriptionsAsync(int userId);
        Task<int> GetTotalCertificatesAsync(int userId);
        Task<PaginatedList<Course>> GetPurchasedCoursesAsync(int userId, PagingRequest request);
        Task<PaginatedList<CourseComment>> GetDiscussionsAsync(int userId, PagingRequest pagingRequest);
        Task<int> GetSubscriptionsAsync(int userId);
        Task<int> GetTotalInstrutorsSubscribingByStudent(int studentId);
        /// <summary>
        /// Get List popular instructor profile
        /// </summary>
        /// <returns>List<AppUser></App></returns>
        List<AppUser> GetListPopularInstructor();
        /// <summary>
        /// Get Role Id by UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int>GetRoleIdByUserId(int userId);
    }
}

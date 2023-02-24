using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IUserSubcriberRepository : IRepository<UserSubcriber>
    {
        /// <summary>
        /// Total new Instrutors Subscribing
        /// </summary>
        /// <returns></returns>
        Task<List<UserSubcriber>> GetTotalNewInstrutorsSubscribing();

        /// <summary>
        /// Total new Students Subscribing
        /// </summary>
        /// <returns></returns>
        Task<List<UserSubcriber>> GetTotalNewStudentSubscribing();

        /// <summary>
        /// Get a list of students subscribed to an instructor.
        /// </summary>
        /// <param name="userId">ID of an instructor to filter</param>
        /// <param name="pagingRequest">Paging request object for paging</param>
        /// <returns>A paged list of type userSubscriber objects</returns>
        Task<PaginatedList<UserSubcriber>> GetStudentsSubscribedAsync(int userId, PagingRequest pagingRequest);

        /// <summary>
        /// Get a list of instructors subscribed by a user.
        /// </summary>
        /// <param name="subscriberId">ID of a user to filter</param>
        /// <param name="pagingRequest">Paging request object for paging</param>
        /// <returns>A paged list of type userSubscriber objects</returns>
        Task<PaginatedList<UserSubcriber>> GetInstrutorsSubsribedAsync(int subscriberId, PagingRequest pagingRequest);

        /// <summary>
        /// Get Total Instrutors Subscribing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserSubcriber>> GetTotalInstrutorsSubscribing();

        /// <summary>
        /// Get Total Student Subscribing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserSubcriber>> GetTotalStudentSubscribing();

    }
}

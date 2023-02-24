using LMS.Model.Response.RevenueStatisticsDTOs;
using LMS.Model.Response.UserSubscriberDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.UserSubscriberServices
{
    public interface IUserSubscriberService
    {
        /// <summary>
        /// Get total subcriber
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>int</returns>
        Task<int> GetTotalSubcriber(int userId);
        /// <summary>
        /// Get Total New Instrutors Subscribing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserSubscriberBasicDTO>> GetTotalNewInstrutorsSubscribing();
        /// <summary>
        /// Get Revenue Statistics Subscribing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<RevenueDTO>> GetRevenueStatisticsSubscribing(int userId);
        /// <summary>
        /// Get Total New Studen Subscribing
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserSubscriberBasicDTO>> GetTotalNewStudenSubscribing();

        /// <summary>
        /// Get Total Instrutors a student subscribed
        /// </summary>
        /// <returns>A number of subscriptions</returns>
        Task<int> GetTotalInstrutorsSubscribing();

        /// <summary>
        /// Get total students subscribed to an instructor
        /// </summary>
        /// <returns>A number of subscriptions</returns>
        Task<int> GetTotalStudentSubscribing();

        /// <summary>
        /// Create a new subscription.
        /// </summary>
        /// <param name="userId">User's ID to subscribe to</param>
        /// <returns>Success: True | Failure: False</returns>
        Task<bool> CreateSubscriptionAsync(int userId);

        /// <summary>
        /// Delete an subscription.
        /// </summary>
        /// <param name="userSubcriber">Subscription to delete</param>
        Task DeleteSubscriptionAsync(UserSubcriber userSubcriber);

        /// <summary>
        /// Get a user subsriber.
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="subscriberId">Subscriber's ID</param>
        /// <returns>An UserSubcriber object</returns>
        Task<UserSubcriber> GetUserSubcriberAsync(int userId, int subscriberId);

        /// <summary>
        /// Get a list of students subscribed to an instructor.
        /// </summary>
        /// <param name="pagingRequest">Paging request object for paging</param>
        /// <returns>A paged list of type userSubscriber objects</returns>
        Task<PagingResult<UserSubscriberDTO>> GetStudentsSubscribedAsync(PagingRequest pagingRequest);

        /// <summary>
        /// Get a list of instructors subscribed by a user.
        /// </summary>
        /// <param name="pagingRequest">Paging request object for paging</param>
        /// <returns>A paged list of type userSubscriber objects</returns>
        Task<PagingResult<UserSubscriberDTO>> GetInstrutorsSubsribedAsync(PagingRequest pagingRequest);

        /// <summary>
        /// Get Revenue Statistics  (random data)
        /// </summary>
        /// <returns></returns>
        Task<List<RevenueDTO>> GetRevenueStatisticsRandomData();


    }
}

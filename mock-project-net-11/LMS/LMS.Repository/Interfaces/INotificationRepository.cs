using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface INotificationRepository:IRepository<Notifications>
    {
        Task<PaginatedList<Notifications>> GetAllNotifications(PagingRequest pagingRequest);
        Task<PaginatedList<Notifications>> GetNotificationsOfUser(int userId, PagingRequest pagingRequest);
        Task<Notifications> GetNotificationByID(int notificationID);     
    }
}

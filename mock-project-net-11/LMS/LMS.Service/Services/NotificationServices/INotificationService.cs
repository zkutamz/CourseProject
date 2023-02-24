using LMS.Model.Request.NotificationDTOs;
using LMS.Model.Response.NotificationDTOs;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.NotificationServices
{
    public interface INotificationService
    {
        Task<PagingResult<NotificationsDTO>> GetAllNotifications(PagingRequest pagingRequest);
        Task<PagingResult<NotificationsDTO>> GetNotificationsOfUser(int userId, PagingRequest pagingRequest);
        Task<NotificationsDTO> GetNotificationByID(int notificationID);
        Task<bool> CreateNotification(NotificationsCreateDTO notificationsCreateDTO);
        Task<bool> CreateNotificationForEventComment(NotificationCreateEvent NotificationCreateEvent);
        Task<bool> CreateNotificationForEventCourse(NotificationCreateEvent NotificationCreateEvent);
        Task<bool> CreateNotificationForEventOthers(NotificationCreateEvent NotificationCreateEvent);
        Task<bool> UpdateNotification(NotificationsEditDTO notificationsEditDTO);
        Task<bool> DeleteNotification(int noticationId);
        Task<bool> ChangeStatusReadNotification(int noticationId);
        /// <summary>
        /// Get the number of unread notifications of user
        /// </summary>
        /// <param name="userId"> Id of User</param>
        /// <returns>(int) total unread notification </returns>
        Task<int> GetNumberUnreadNotificationsByUserId(int userId);
    }
}

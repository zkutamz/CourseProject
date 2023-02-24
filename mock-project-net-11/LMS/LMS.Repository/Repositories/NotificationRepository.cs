using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class NotificationRepository : Repository<Notifications>, INotificationRepository
    {
        public NotificationRepository(LMSApplicationContext context, ILogger<NotificationRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }

        /// <summary>
        /// Get All list notifications.
        /// </summary>
        /// <returns>List of notifications</returns>
        private async Task<List<Notifications>> GetAll()
        {
            try
            {
                var notifications = await Context.Notifications
                                   .Include(p => p.User)
                                   .ToListAsync();
                return notifications;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All Notifications failed", nameof(GetAll));
                throw;
            }
        }

        /// <summary>
        /// Get All Notifications and paging by paging request
        /// </summary>
        /// <param name="pagingRequest">PagingResult<Notifications></param>
        /// <returns>PaginatedList<Notifications></returns>
        public async Task<PaginatedList<Notifications>> GetAllNotifications(PagingRequest pagingRequest)
        {
            try
            {
                var paginatedList = await GetAllAsync(pagingRequest, n => (n.IsDelete == false && n.IsRead==false), n => n.User);
                return paginatedList;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All Notifications Paging failed", nameof(GetAllNotifications));
                throw;
            }
        }

        /// <summary>
        /// Get Notifications Of User
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="pagingRequest">PagingRequest pagingRequest</param>
        /// <returns>PaginatedList<Notifications></returns>
        public async Task<PaginatedList<Notifications>> GetNotificationsOfUser(int userId, PagingRequest pagingRequest)
        {
            try
            {
                //var paginatedList = await GetAllAsync(pagingRequest, n => (n.UserId == userId && n.IsDelete == false), n => n.User);
                var notiList = Context.Notifications.Where(n => n.UserId == userId && n.IsDelete == false)
                    .Include(n => n.User)
                    .OrderByDescending(n => n.CreatedAt);
                    

                var paginatedList = await PaginatedList<Notifications>.ToPaginatedListAsync(notiList, pagingRequest.PageNumber, pagingRequest.PageSize);
                return paginatedList;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All Notifications of User Paging failed", nameof(GetAllNotifications));
                throw;
            }
        }

        /// <summary>
        /// Get Notification By ID
        /// </summary>
        /// <param name="notificationID"></param>
        /// <returns>Notifications</returns>
        public async Task<Notifications> GetNotificationByID(int notificationID)
        {
            try
            {
                var notification = await GetAsync(n => (n.Id== notificationID && n.IsDelete == false && n.IsRead==false), n => n.User);
                return notification;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get Notification by ID failed", nameof(GetNotificationByID));
                throw;
            }
        }
    }
}

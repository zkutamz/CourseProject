using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.NotificationDTOs;
using LMS.Model.Utilities;
using LMS.Repository.Paging;
using LMS.Service.Services.NotificationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController
    {
        private readonly ILogger<NotificationsController> _logger;
        private readonly INotificationService _notificationService;

        public NotificationsController(ILogger<NotificationsController> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Get All Notifications
        /// </summary>
        /// <returns>200 and list Notification, 400: ResponseResult</returns>
        [HttpGet("get-all-notifications")]
        public async Task<IActionResult> GetAllNotifications([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _notificationService.GetAllNotifications(pagingRequest);
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get All Notifications in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Get Notifications Of User
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="pagingRequest">PagingRequest pagingRequest</param>
        /// <returns>Paginresult NotificationDTO</returns>
        [HttpGet("get-notifications-for-user/{userId}")]
        public async Task<IActionResult> GetNotificationsOfUser(int userId, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _notificationService.GetNotificationsOfUser(userId, pagingRequest);
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get All Notifications of User in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Get Notification By ID
        /// </summary>
        /// <param name="notificationID"></param>
        /// <returns>NotificationDTO</returns>
        [HttpGet("get-notifications-by-id/{notificationID}")]
        public async Task<IActionResult> GetNotificationByID(int notificationID)
        {
            try
            {
                if (notificationID < 0)
                {
                    throw new BadRequestException(ResponseMessage.GetDataFailed);
                }
                var result = await _notificationService.GetNotificationByID(notificationID);
                if (result == null)
                {
                    throw new BadRequestException(ResponseMessage.GetDataFailed);
                }
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get Notification by ID in API");
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// API get the number of unread notifications by userId
        /// </summary>
        /// <param name="userId">id of user</param>
        /// <returns>ResponeseResult with data is total unread notification of user</returns>
        /// <exception cref="BadRequestException">return if userid not in DB</exception>
        [HttpGet("get-the-number-of-unread-notifications/{userId}")]
        public async Task<ActionResult<ResponseResult<int>>> GetUnReadNotifications(int userId)
        {
            try
            {
                if (userId < 0)
                {
                    throw new BadRequestException(ResponseMessage.GetDataFailed);
                }
                var result = await _notificationService.GetNumberUnreadNotificationsByUserId(userId);

                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get Number Unread Notification by UserId in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Update Notification
        /// </summary>
        /// <param name="notificationsEditDTO">NotificationsEditDTO notificationsEditDTO</param>
        /// <returns>true:success, false: failed</returns>
        [HttpPut("update-notification/{notificationID}")]
        public async Task<IActionResult> UpdateNotification(int notificationID, [FromForm] NotificationsEditDTO notificationsEditDTO)
        {
            try
            {
                notificationsEditDTO.Id = notificationID;
                var result = await _notificationService.UpdateNotification(notificationsEditDTO);
                if (result == false)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Update Notification in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Delete Notification
        /// </summary>
        /// <param name="notificationID">int notificationID</param>
        /// <returns>true:success, false: failed</returns>
        [HttpPut("delete-notification/{notificationID}")]
        public async Task<IActionResult> DeleteNotification(int notificationID)
        {
            try
            {
                var result = await _notificationService.DeleteNotification(notificationID);
                if (result == false)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Delete Notification in API");
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// Change Status Read ReadNotification
        /// </summary>
        /// <param name="notificationID">notificationID</param>
        /// <returns>true:success, false: failed</returns>
        [HttpPut("change-status-read/{notificationID}")]
        public async Task<IActionResult> ChangeStatusReadNotification(int notificationID)
        {
            try
            {
                var result = await _notificationService.ChangeStatusReadNotification(notificationID);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Change Status Read ReadNotification in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create Notification
        /// </summary>
        /// <param name="notificationsCreateDTO">NotificationsCreateDTO notificationsCreateDTO</param>
        /// <returns></returns>
        [HttpPost("create-notification")]
        public async Task<IActionResult> CreateNotification([FromForm] NotificationsCreateDTO notificationsCreateDTO)
        {
            try
            {
                var result = await _notificationService.CreateNotification(notificationsCreateDTO);
                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Notification in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create Notification Event Course
        /// </summary>
        /// <param name="notificationCreateEvent"></param>
        /// <returns></returns>
        [HttpPost("create-notification-by-event-course")]
        public async Task<IActionResult> CreateNotificationForEventCourse([FromForm] NotificationCreateEvent notificationCreateEvent)
        {
            try
            {
                var result = await _notificationService.CreateNotificationForEventCourse(notificationCreateEvent);
                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Notification by envet Course in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create Notification Event Comment
        /// </summary>
        /// <param name="notificationCreateEvent"></param>
        /// <returns></returns>
        [HttpPost("create-notification-by-event-comment")]
        public async Task<IActionResult> CreateNotificationForEventComment([FromForm] NotificationCreateEvent notificationCreateEvent)
        {
            try
            {
                var result = await _notificationService.CreateNotificationForEventComment(notificationCreateEvent);
                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Notification by envet comment in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create Notification Event Others
        /// </summary>
        /// <param name="notificationCreateEvent"></param>
        /// <returns></returns>
        [HttpPost("create-notification-by-event-others")]
        public async Task<IActionResult> CreateNotificationForEventOthers([FromForm] NotificationCreateEvent notificationCreateEvent)
        {
            try
            {
                var result = await _notificationService.CreateNotificationForEventOthers(notificationCreateEvent);
                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Notification by envet others in API");
                throw new BadRequestException(ex.Message);
            }
        }
    }
}

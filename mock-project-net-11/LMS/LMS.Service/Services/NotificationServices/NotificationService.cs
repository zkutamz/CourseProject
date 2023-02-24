using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Request.NotificationDTOs;
using LMS.Model.Response.NotificationDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NotificationService> _logger;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork unitOfWork, ILogger<NotificationService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Create Notification
        /// </summary>
        /// <param name="notificationsCreateDTO">NotificationsCreateDTO notificationsCreateDTO</param>
        /// <returns>true: success, false: failed</returns>
        public async Task<bool> CreateNotification(NotificationsCreateDTO notificationsCreateDTO)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var notification = _mapper.Map<Notifications>(notificationsCreateDTO);
                notification.CreatedAt = DateTime.Now;
                notification.UpdatedAt = DateTime.Now;
                notification.IsRead = false;
                var result = await _unitOfWork.NotificationRepository.AddAsync(notification);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Notification failed in service", nameof(CreateNotification));
                throw;
            }
        }
        /// <summary>
        /// Get Notifications Of User
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <param name="pagingRequest">PagingRequest pagingRequest</param>
        /// <returns>PagingResult<NotificationsDTO></returns>
        public async Task<PagingResult<NotificationsDTO>> GetNotificationsOfUser(int userId, PagingRequest pagingRequest)
        {
            try
            {
                var paginatedList = _mapper.Map<PaginatedList<Notifications>, PaginatedList<NotificationsDTO>>(await _unitOfWork.NotificationRepository.GetNotificationsOfUser(userId, pagingRequest));
                //var listTemp = new List<NotificationsDTO>();
                //listTemp = paginatedList.OrderByDescending(x => x.CreatedAt).ToList();

                var pageResult = new PagingResult<NotificationsDTO>()
                {
                    TotalCount = paginatedList.TotalCount,
                    PageSize = paginatedList.PageSize,
                    TotalPages = paginatedList.TotalPages,
                    CurrentPage = paginatedList.CurrentPage,
                    Objects = paginatedList
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get All Notifications of user Paging failed in service", nameof(GetNotificationsOfUser));
                throw;
            }
        }

        /// <summary>
        /// Get All Notifications
        /// </summary>
        /// <param name="pagingRequest">PagingRequest pagingRequest</param>
        /// <returns>PagingResult<NotificationsDTO></returns>
        public async Task<PagingResult<NotificationsDTO>> GetAllNotifications(PagingRequest pagingRequest)
        {
            try
            {
                var paginatedList = _mapper.Map<PaginatedList<Notifications>, PaginatedList<NotificationsDTO>>(await _unitOfWork.NotificationRepository.GetAllNotifications(pagingRequest));
                var pageResult = new PagingResult<NotificationsDTO>()
                {
                    TotalCount = paginatedList.TotalCount,
                    PageSize = paginatedList.PageSize,
                    TotalPages = paginatedList.TotalPages,
                    CurrentPage = paginatedList.CurrentPage,
                    Objects = paginatedList
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get All Notifications Paging failed in service", nameof(GetAllNotifications));
                throw;
            }
        }

        /// <summary>
        /// Update Notification
        /// </summary>
        /// <param name="notificationsCreateDTO"></param>
        /// <returns>true: success, false: failed</returns>
        public async Task<bool> UpdateNotification(NotificationsEditDTO notificationsEditDTO)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var notification = _mapper.Map<Notifications>(notificationsEditDTO);
                notification.UpdatedAt = DateTime.Now;
                var result = await _unitOfWork.NotificationRepository.UpdateAsync(notification);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Notification failed in service", nameof(UpdateNotification));
                throw;
            }
        }

        /// <summary>
        /// Delete Notification
        /// </summary>
        /// <param name="noticationId">int notificationID</param>
        /// <returns>true: success, false: failed</returns>
        public async Task<bool> DeleteNotification(int notificationID)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var notification = await _unitOfWork.NotificationRepository.GetNotificationByID(notificationID);
                notification.IsDelete = true;
                var result = await _unitOfWork.NotificationRepository.UpdateAsync(notification);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Delete Notification failed in service", nameof(DeleteNotification));
                throw;
            }
        }

        /// <summary>
        /// Get Notification By ID
        /// </summary>
        /// <param name="notificationID">int notificationID</param>
        /// <returns>NotificationsDTO</returns>
        public async Task<NotificationsDTO> GetNotificationByID(int notificationID)
        {
            try
            {
                var notificationDTO = _mapper.Map<NotificationsDTO>(await _unitOfWork.NotificationRepository.GetNotificationByID(notificationID));
                return notificationDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get Notification by ID failed in service", nameof(GetNotificationByID));
                throw;
            }
        }

        /// <summary>
        /// Create Notification Event Course: Register, Update, Delete, Comment, Review, Receive certificate.
        /// </summary>
        /// <param name="notificationCreateEvent"></param>
        /// <returns></returns>
        public async Task<bool> CreateNotificationForEventCourse(NotificationCreateEvent notificationCreateEvent)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            var result = true;
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == notificationCreateEvent.CourseID);// Get course by courseId
                var instructor = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == course.InstructorId);// Get instructor by instructorId in Course.
                var user = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == notificationCreateEvent.UserID);// Get student or instructor by userID.            
                if (course == null|| instructor == null || user == null)
                {
                    _logger.LogError("Missing data", "{0} {1}", "Create Notification by event failed in service", nameof(CreateNotificationForEventCourse));
                    return false;
                }
                #region Notification when Student register, review, comment in the course
                if (user.Id != instructor.Id)
                {
                    // Create notification for instructor.
                    var notificationInstructor = new Notifications();
                    notificationInstructor.CreatedAt = DateTime.Now;
                    notificationInstructor.UpdatedAt = DateTime.Now;
                    notificationInstructor.IsRead = false;
                    if (user.Id != instructor.Id)
                    {
                        notificationInstructor.Header = user.FirstName + " " + user.LastName;
                    }
                    else
                    {
                        notificationInstructor.Header = "";
                    }
                    notificationInstructor.UserId = instructor.Id;
                    notificationInstructor.Message = GetDetailByTypeNotificationCourse(notificationCreateEvent.TypeNotification, user, course, 0);
                    notificationInstructor.Details = "";
                    result = await _unitOfWork.NotificationRepository.AddAsync(notificationInstructor);
                    // Create Notification for student.
                    var notificationStudent = new Notifications()
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsRead = false,
                        Header = "",
                        UserId = user.Id,
                        Message = GetDetailByTypeNotificationCourse(notificationCreateEvent.TypeNotification, user, course, user.Id),
                        Details = "",
                    };
                    result = await _unitOfWork.NotificationRepository.AddAsync(notificationStudent);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                } 
                #endregion
                #region Notification when Instructor create, update, delete in the course.
                if (user.Id == instructor.Id)
                {
                    var notificationInstructor = new Notifications()
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsRead = false,
                        Header = "",
                        UserId = instructor.Id,
                        Message = GetDetailByTypeNotificationCourse(notificationCreateEvent.TypeNotification, user, course, 0),
                        Details = "",
                    };
                    result = await _unitOfWork.NotificationRepository.AddAsync(notificationInstructor);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                } 
                #endregion
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Notification by event failed in service", nameof(CreateNotificationForEventCourse));
                throw;
            }
        }

        /// <summary>
        /// Create Notification Event Comment: like, reply to comment course
        /// </summary>
        /// <param name="notificationCreateEvent">NotificationCreateEvent notificationCreateEvent</param>
        /// <returns>true: success, false: failed</returns>
        public async Task<bool> CreateNotificationForEventComment(NotificationCreateEvent notificationCreateEvent)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == notificationCreateEvent.UserID);// Get student or instructor by userID.
                var comment = await _unitOfWork.CourseCommentRepository.GetAsync(c => c.Id == notificationCreateEvent.CommentID);// Get comment by commentID
                var course = await _unitOfWork.CourseRepository.GetAsync(c=>c.Id == comment.CourseId);
                var userOfComment = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == comment.UserId);
                if (user == null || comment== null)
                {
                    _logger.LogError("Missing data", "{0} {1}", "Create Notification by event failed in service", nameof(CreateNotificationForEventComment));
                    return false;
                }
                var notificationStudent = new Notifications()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsRead = false,
                    Header = "",
                    UserId = userOfComment.Id,
                    Message = GetDetailByTypeNotificationComment(notificationCreateEvent.TypeNotification, user,course),
                    Details = comment.Content,
                };
                var result = await _unitOfWork.NotificationRepository.AddAsync(notificationStudent);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Notification by event failed in service", nameof(CreateNotificationForEventComment));
                throw;
            }
        }

        /// <summary>
        /// Create Notification Event Comment: ActivedMembership, UploadVideo, 
        /// </summary>
        /// <param name="notificationCreateEvent"></param>
        /// <returns></returns>
        public async Task<bool> CreateNotificationForEventOthers(NotificationCreateEvent notificationCreateEvent)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == notificationCreateEvent.UserID);// Get student or instructor by userID.
                if (user == null)
                {
                    _logger.LogError("Missing data", "{0} {1}", "Create Notification by event failed in service", nameof(CreateNotificationForEventOthers));
                    return false;
                }
                var notificationUser = new Notifications()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsRead = false,
                    Header = "",
                    UserId = user.Id,
                    Message = GetDetailByTypeNotificationOthers(notificationCreateEvent.TypeNotification),
                    Details = "",
                };
                var result = await _unitOfWork.NotificationRepository.AddAsync(notificationUser);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Notification by event failed in service", nameof(CreateNotificationForEventOthers));
                throw;
            }
        }

        /// <summary>
        /// Get Detail By Type Notification event Course
        /// </summary>
        /// <param name="typeNotification">TypeNotification typeNotification</param>
        /// <param name="user">AppUser user</param>
        /// <param name="course">Course course</param>
        /// <param name="studentID">studentID</param>
        /// <returns>string message</returns>
        private string GetDetailByTypeNotificationCourse(TypeNotification typeNotification, AppUser user, Course course, int studentID)
        {
            if (user.Id != course.InstructorId && studentID == 0)// Notification activity student for instructor.
            {
                if (typeNotification == TypeNotification.RegisterCourse)
                {
                    return (user.FirstName + " " + user.LastName + " Register Your Course " + course.Title);
                }
                else if (typeNotification == TypeNotification.ReviewCourse)
                {
                    return (user.FirstName + " " + user.LastName + " Added new review in Video " + course.Title);
                }
                else if (typeNotification == TypeNotification.CommentCourse)
                {
                    return (user.FirstName + " " + user.LastName + " Added new comment on video " + course.Title);
                }
            }
            else if (user.Id != course.InstructorId && studentID > 0)// Notification activity student for student.
            {
                if (typeNotification == TypeNotification.RegisterCourse)
                {
                    return ("You buy a new Course " + course.Title);
                }
                else if (typeNotification == TypeNotification.ReviewCourse)
                {
                    return ("You Review Course " + course.Title);
                }
                else if (typeNotification == TypeNotification.CommentCourse)
                {
                    return ("You Comment Course " + course.Title);
                }
            }
            else if (user.Id == course.InstructorId)// Notification of instructor for instructor.
            {
                if (typeNotification == TypeNotification.RegisterCourse)
                { 
                    return ("You Create Course " + course.Title);
                }
                else if (typeNotification == TypeNotification.UpdateCourse)
                {
                    return ("You Update Course " + course.Title);
                }
                else if (typeNotification == TypeNotification.DeleteCourse)
                {
                    return ("You Delete Course " + course.Title);
                }
            }
            return "New Notification !!!";
        }
       
        /// <summary>
        /// Get Detail By Type Notification event Comment
        /// </summary>
        /// <param name="typeNotification"></param>
        /// <param name="user"></param>
        /// <param name="course"></param>
        /// <returns>string message</returns>
        private string GetDetailByTypeNotificationComment(TypeNotification typeNotification, AppUser user, Course course)
        {
            if (typeNotification == TypeNotification.LikeComment)
            {
                return (user.FirstName + " " + user.LastName + " Like your comment on video " + course.Title);
            }
            else if (typeNotification == TypeNotification.ReplyComment)
            {
                return (user.FirstName + " " + user.LastName + " Reply your comment on video " + course.Title);
            }
            return "New Notification !!!";
        }
       
        /// <summary>
        /// Get Detail By Type Notification event others: ActivedMembership, UploadVideo
        /// </summary>
        /// <param name="typeNotification"></param>
        /// <returns></returns>
        private string GetDetailByTypeNotificationOthers(TypeNotification typeNotification)
        {
            if (typeNotification == TypeNotification.ActivedMembership)
            {
                return ("Your membership Actived");
            }
            else if (typeNotification == TypeNotification.UploadVideo)
            {
                return ("Your membership upload video");
            }
            return "New Notification !!!";
        }

        public async Task<bool> ChangeStatusReadNotification(int noticationId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var notification = await _unitOfWork.NotificationRepository.GetNotificationByID(noticationId);
                if (notification==null)
                {
                    _logger.LogError("Not found notification to update", nameof(ChangeStatusReadNotification));
                    return false;
                }
                notification.IsRead = true;
                var result = await _unitOfWork.NotificationRepository.UpdateAsync(notification);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Change Status Read Notification failed in service", nameof(ChangeStatusReadNotification));
                throw;
            }
        }

        public async Task<int> GetNumberUnreadNotificationsByUserId(int userId)
        {
            try
            {
                if (userId < 0)
                {
                    _logger.LogError("Missing data", "{0} {1}", "Get number Unread Notification by userId failed in service", nameof(CreateNotificationForEventOthers));
                    return 0;
                }
                var notifications = await _unitOfWork.NotificationRepository.GetAllAsyncNoPaging(n => (n.UserId == userId && n.IsDelete == false && n.IsRead == false));
                return notifications.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get number Unread Notification by userId failed in service", nameof(GetNumberUnreadNotificationsByUserId));
                throw;
            }
        }
    }
}

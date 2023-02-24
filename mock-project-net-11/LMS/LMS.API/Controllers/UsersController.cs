using LMS.API.Extensions;
using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.AppUserDTOs;
using LMS.Model.Request.BillingAddressDTOs;
using LMS.Model.Request.NotificationSettingDTOs;
using LMS.Model.Request.PrivacySettingDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.BillingAddressServices;
using LMS.Service.Services.CourseService;
using LMS.Service.Services.InstructorServices;
using LMS.Service.Services.NotificationSettingServices;
using LMS.Service.Services.PrivacySettingServices;
using LMS.Service.Services.UserServices;
using LMS.Service.Services.UserSubscriberServices;
using LMS.Service.Services.VisitorServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserSubscriberService _userSubscriberService;
        private readonly INotificationSettingService _notificationSettingService;
        private readonly IPrivacySettingService _privacySettingService;
        private readonly IBillingAddressService _billingAddressService;
        private readonly IVisitorService _visitorService;
        private readonly ICourseService _courseService;
        private readonly ActionOptions _actionOptions;
        private readonly IInstructorService _instructorService;

        public UsersController(IUserService userService,
            IUserSubscriberService userSubcriberService,
            INotificationSettingService notificationSettingService,
            IPrivacySettingService privacySettingService,
            IBillingAddressService billingAddressService,
            IVisitorService visitorService,
            ICourseService courseService,
            IOptionsSnapshot<ActionOptions> actionOptions,
            IInstructorService instructorService)
        {
            _userService = userService;
            _userSubscriberService = userSubcriberService;
            _notificationSettingService = notificationSettingService;
            _privacySettingService = privacySettingService;
            _billingAddressService = billingAddressService;
            _visitorService = visitorService;
            _courseService = courseService;
            _actionOptions = actionOptions.Value;
            _instructorService = instructorService;
        }

        /// <summary>
        /// Get total course purchase
        /// </summary>
        /// <returns></returns>
        [HttpGet("total-course-purchase")]
        public async Task<IActionResult> GetTotalCoursePurchase()
        {
            try
            {
                var userId = User.GetUserId();
                if (userId != 0)
                {
                    return HandleResult(await _userService.GetTotalCoursePurchaseAsync(userId), LmsAction.Get);
                }

                throw new AuthorizedException();
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get total reviews
        /// </summary>
        /// <returns></returns>
        [HttpGet("total-reviews")]
        public async Task<IActionResult> GetTotalReviews()
        {
            try
            {
                var userId = User.GetUserId();
                if (userId != 0)
                {
                    return HandleResult(await _userService.GetTotalReviewsAsync(userId), LmsAction.Get);
                }

                throw new AuthorizedException();
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get total subscriptions
        /// </summary>
        /// <returns></returns>
        [HttpGet("total-subscriptions")]
        public async Task<IActionResult> GetTotalSubscriptions()
        {
            try
            {
                var userId = User.GetUserId();
                if (userId != 0)
                {
                    return HandleResult(await _userService.GetTotalSubscriptionsAsync(userId), LmsAction.Get);
                }

                throw new AuthorizedException();
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get total certificates
        /// </summary>
        /// <returns></returns>
        [HttpGet("total-certificates")]
        public async Task<IActionResult> GetTotalCertificates()
        {
            try
            {
                var userId = User.GetUserId();
                if (userId != 0)
                {
                    return HandleResult(await _userService.GetTotalCertificatesAsync(userId), LmsAction.Get);
                }

                throw new AuthorizedException();
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get about me of user logged
        /// </summary>
        /// <returns></returns>
        [HttpGet("about-me")]
        public async Task<IActionResult> GetAboutMe()
        {
            try
            {
                var userId = User.GetUserId();
                if (userId != 0)
                {
                    return HandleResult(await _userService.GetAboutMeAsync(userId), LmsAction.Get);
                }

                throw new AuthorizedException();
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get purchased courses
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpPost("{userId}/purchased-courses")]
        public async Task<IActionResult> GetPurchasedCourses(int userId, PagingRequest pagingRequest)
        {
            try
            {
                var result = await _courseService.GetAllPurchasedCoursesOfStudent(userId, pagingRequest);
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return HandleResult(user, LmsAction.Get);
        }

        /// <summary>
        /// Edit info user logged 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AppUserDTO user)
        {
            try
            {
                await _userService.UpdateAsync(id, user);
                return HandleResult(Ok(), LmsAction.Update);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }

        }


        /// <summary>
        /// Update notification setting of user logged
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update-notification-setting")]
        public async Task<IActionResult> UpdateNotificationSetting(NotificationSettingEditDTO request)
        {
            var userId = User.GetUserId();
            if (userId != 0)
            {
                await _notificationSettingService.UpdateAsync(userId, request);
                return HandleResult(Ok(), LmsAction.Update);
            }
            throw new UnauthorizedAccessException();
        }

        /// <summary>
        /// Update privacy setting of user logged
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update-privacy-setting")]
        public async Task<IActionResult> UpdatePrivacySetting(PrivacySettingEditDTO request)
        {
            var userId = User.GetUserId();
            if (userId != 0)
            {
                await _privacySettingService.UpdateAsync(userId, request);
                return HandleResult(Ok(), LmsAction.Update);
            }
            throw new UnauthorizedAccessException();
        }

        /// <summary>
        /// Update billing address of user logged
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update-billing-address")]
        public async Task<IActionResult> UpdateBillingAddress(BillingAddressEditDTO request)
        {
            var userId = User.GetUserId();
            if (userId != 0)
            {
                await _billingAddressService.UpdateAsync(userId, request);
                return HandleResult(Ok(), LmsAction.Update);
            }
            throw new UnauthorizedAccessException();
        }

        /// <summary>
        /// Get total view course of instructor by day
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="date">MM/dd/yyyy Ex:(02/20/2022)</param>
        /// <returns>int</returns>
        [HttpGet("{instructorId}/get-total-view-instructor-by-day")]
        public async Task<IActionResult> GetTotalViewInstructorByDay(int instructorId, [Required] string date)
        {
            return HandleResult(await _visitorService.GetViewDaily(instructorId, date), LmsAction.Get);
        }
        /// <summary>
        /// Get list view of instructor weekly. from date now to past
        /// Get view 7 day latest
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="date">MM/dd/yyyy ex: 01/14/2021</param>
        /// <returns>int</returns>
        //[HttpGet("{instructorId}/get-view-of-course-of-instructor-weekly")]
        //public async Task<IActionResult> GetTotalViewInstructorByWeek(int instructorId, [Required] string date)
        //{
        //    date = date.Replace("%2F", "/");
        //    DateTime dateTime = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        //    int totalView = await _visitorService.GetTotalViewWeekly(instructorId, dateTime.ToString());
        //    return HandleResult(totalView, LmsAction.Get);
        //}

        /// <summary>
        /// Get New Instructor Subscribing
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>




        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appUserChangePassword"></param>
        /// <returns>True if success and false if fail</returns>
        [HttpPut]
        [Route("change-password/{id}")]
        public async Task<IActionResult> ChangePassword(int id, AppUserChangePasswordDTO appUserChangePassword)
        {
            return HandleResult(await _userService.ChangeUserPassword(id, appUserChangePassword), LmsAction.Update);
        }

        /// <summary>
        /// Up vote or down vote a user. 
        /// Each users can only up or down vote once.
        /// </summary>
        /// <param name="id">ID of a user who got voted</param>
        /// <param name="isUpVote">If true then the user will get up vote, else will get down vote</param>
        /// <returns>True if success, else return false</returns>\
        //[Authorize]
        [HttpPut("{id:int}/vote")]
        public async Task<ActionResult<bool>> VoteAUser(int id, bool isUpVote)
        {
            return HandleResult(await _userService.VoteAUserAsync(id, isUpVote), _actionOptions.Update);
        }

        /// <summary>
        /// Get all instructor
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUser()
        {
            return HandleResult(await _userService.GetAllInstructorUser(), LmsAction.Get);
        }
    }
}

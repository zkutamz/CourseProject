using LMS.API.Extensions;
using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Response.UserSubscriberDTOs;
using LMS.Repository.Paging;
using LMS.Service.Extensions;
using LMS.Service.Services.UserServices;
using LMS.Service.Services.UserSubscriberServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : BaseController
    {
        private readonly IUserSubscriberService _userSubscriberService;
        private readonly ILogger<SubscribersController> _logger;
        private readonly ActionOptions _actionOptions;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly IUserService _userService;
        private readonly IUserAccessor _userAccessor;

        public SubscribersController(
            IUserSubscriberService userSubscriberService,
            IOptionsSnapshot<ActionOptions> actionOptions,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            ILogger<SubscribersController> logger,
            IUserService userService,
            IUserAccessor userAccessor)
        {
            _userSubscriberService = userSubscriberService;
            _actionOptions = actionOptions.Value;
            _responseMessage = responseMessage.Value;
            _logger = logger;
            _userService = userService;
            _userAccessor = userAccessor;
        }


        /// <summary>
        /// Get New Instructor Subscribing
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("NewInstructorSubscribing")]
        public async Task<IActionResult> GetNewInstructorSubscribing()
        {
            try
            {
                var result = await _userSubscriberService.GetTotalNewInstrutorsSubscribing();
                return HandleResult(result);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"{_responseMessage.ErrorOccurred} {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get New Student Subscribing
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("GetNewStudentSubscribing")]
        public async Task<IActionResult> GetNewStudentSubscribing()
        {
            try
            {
                var result = await _userSubscriberService.GetTotalNewStudenSubscribing();
                return HandleResult(result);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"{_responseMessage.ErrorOccurred} {e.InnerException?.Message}");
            }
        }
        /// <summary>
        /// Get a total number of subscriptions of a user.
        /// </summary>
        /// <remarks>Can use any account. The user's ID will be get when a token passed in.</remarks>
        /// <returns>A total number of subscriptions</returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("total-subscriptions")]
        [Authorize]
        public async Task<ActionResult<int>> InstructorSubscribing()
        {
            try
            {
                var result = await _userSubscriberService.GetTotalInstrutorsSubscribing();
                return HandleResult(result);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"{_responseMessage.ErrorOccurred} {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get a total number of subscribers of an instructor.
        /// </summary>
        /// <remarks>Must use an instructor's account. The instructor's ID will be get when a token passed in.</remarks>
        /// <returns>A total number of subscribers</returns>/// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [Authorize(Roles = Roles.INSTRUCTOR)]
        [HttpGet("total-subscribers")]
        public async Task<IActionResult> StudentSubscribing()
        {
            try
            {
                var result = await _userSubscriberService.GetTotalStudentSubscribing();
                return HandleResult(result);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"{_responseMessage.ErrorOccurred} {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get all instructors an student subscribed.
        /// </summary>
        /// <remarks>Can use any account. The instructor's ID will be get when a token passed in.</remarks>
        /// <param name="pagingRequest">Paging request object for paging</param>
        /// <returns>A paged list of userSubscriber DTO objects</returns>
        [Authorize]
        [HttpGet("subscriptions")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagingResult<UserSubscriberDTO>>> GetInstructorsSubscribed([FromQuery] PagingRequest pagingRequest = null)
        {
            try
            {
                if (pagingRequest is null) pagingRequest = new PagingRequest();

                var userSubscribers = await _userSubscriberService.GetInstrutorsSubsribedAsync(pagingRequest);

                return Ok(userSubscribers);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetInstructorsSubscribed));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }
        /// <summary>
        /// Get total of User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}/total-subcribers")]
        public async Task<IActionResult> GetTotalSubcriber(int userId)
        {
            var totalSubcriber = await _userSubscriberService.GetTotalSubcriber(userId);
            return HandleResult(totalSubcriber, LmsAction.Get);
        }
        [HttpGet("GetTotalInstructorsSub")]
        public async Task<IActionResult> GetTotalInstructorsSub(int studentId)
        {
            try
            {
                return HandleResult(await _userService
                    .GetTotalInstructorsSubscribing(studentId), LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }

        }
        [Authorize]
        [HttpGet("RevenueStatisticsSubscribing")]
        public async Task<IActionResult> RevenueStatisticsSubscribing()
        {
            try
            {
                var userId = User.GetUserId();
                if (userId != 0)
                {
                    var result = await _userSubscriberService.GetRevenueStatisticsSubscribing(userId);
                    return HandleResult(result, LmsAction.Add);
                }
                throw new UnauthorizedAccessException();
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.InnerException?.Message}");
            }
        }
        [HttpGet("RevenueStatisticsRandomData")]
        public async Task<IActionResult> RevenueStatisticsRandomData()
        {
            try
            {

                var result = await _userSubscriberService.GetRevenueStatisticsRandomData();
                return HandleResult(result, LmsAction.Add);

            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.InnerException?.Message}");
            }
        }

        /// <summary>
        /// Get all students subscribed to an instructor.
        /// </summary>
        /// <remarks>Must use an instructor's account. The user's ID will be get when a token passed in.</remarks>
        /// <param name="pagingRequest">Paging request object for paging</param>
        /// <returns>A paged list of userSubscriber DTO objects</returns>
        [Authorize(Roles = Roles.INSTRUCTOR)]
        [HttpGet("subscribers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagingResult<UserSubscriberDTO>>> GetUsersSubscribed([FromQuery] PagingRequest pagingRequest = null)
        {
            try
            {
                if (pagingRequest is null) pagingRequest = new PagingRequest();

                var userSubscribers = await _userSubscriberService.GetStudentsSubscribedAsync(pagingRequest);

                if (userSubscribers is null) throw new Exception(_responseMessage.GetDataFailed);

                return Ok(userSubscribers);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetUsersSubscribed));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }

        /// <summary>
        /// Create a new subscription.  (Subscribe to a user)
        /// </summary>
        /// <remarks>The subsriber's ID will be retrieved in the provided token</remarks>
        /// <param name="userId">User's ID to subscribe to</param>
        /// <returns>Success: True | Failure: False</returns>
        /// <response code="201">Return true if create successfully</response>
        /// <response code="400">If the provided user's ID is invalid</response>
        /// <response code="401">If not login</response>
        /// <response code="404">If there is no user found</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpPost("{userId:int}")]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> CreateSubscription(int userId)
        {
            try
            {
                if (userId <= 0) return BadRequest(_responseMessage.InvalidParameters);

                if (await _userService.GetById(userId) is null) return NotFound(_responseMessage.NotFound);

                return CreatedAtAction(null, await _userSubscriberService.CreateSubscriptionAsync(userId));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateSubscription));
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Unsubscribe from a user
        /// </summary>
        /// <remarks>The subsriber's ID will be retrieved in the provided token</remarks>
        /// <param name="userId">User's ID to unsubscribe from</param>
        /// <returns>Success: True | Failure: False</returns>
        /// <response code="204">If success</response>
        /// <response code="400">If the provided user's ID is invalid</response>
        /// <response code="401">If not login</response>
        /// <response code="404">If there is no user found</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpDelete("{userId:int}")]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteSubscription(int userId)
        {
            try
            {
                if (userId <= 0) return BadRequest(_responseMessage.InvalidParameters);

                var subscriberId = await _userAccessor.GetUserId();

                if (subscriberId <= 0) throw new Exception(_responseMessage.LoginFailure);

                if (await _userService.GetById(userId) is null) return NotFound(_responseMessage.NotFound);

                var userSubscriber = await _userSubscriberService.GetUserSubcriberAsync(userId, subscriberId);

                if (userSubscriber is null) return NotFound(_responseMessage.NotFound);

                await _userSubscriberService.DeleteSubscriptionAsync(userSubscriber);

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(DeleteSubscription));
                return StatusCode(500, e.Message);
            }
        }
    }
}

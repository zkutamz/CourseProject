using LMS.Model.Constant;
using LMS.Model.Request.FeedbackDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.FeedbackServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : BaseController
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }
        /// <summary>
        /// API get Feedback of User
        /// </summary>
        /// <param name="pagingRequest">PageSize: number record; PageCurrent: position page</param>
        /// <returns>Response</returns>
        [HttpGet]
        public async Task<IActionResult> GetFeedback([FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await feedbackService.GetFeedbackAsyncPaging(pagingRequest));
        }
        /// <summary>
        /// API get Feedback of specify User 
        /// </summary>
        /// <param name="userId">Id of User</param>
        /// <param name="pagingRequest"></param>
        /// <returns>Response</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFeedbackUserById(int userId, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await feedbackService.GetFeedbackUserByIdAsyncPaging(userId, pagingRequest));
        }
        /// <summary>
        /// API create Feedback of User
        /// </summary>
        /// <param name="request">Feedback information create</param>
        /// <param name="screenShot">File screenShot</param>
        /// <returns>Response</returns>
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromForm] FeedbackCreateDTO request)
        {
            return HandleResult(await feedbackService.CreateFeedbackAsync(request), LmsAction.Add);
            // return HandleResult(await feedbackService.CreateFeedbackAsync(request,screenShot), LmsAction.Add);
        }
        /// <summary>
        /// API answer the question Feedback of User
        /// /// </summary>
        /// <param name="id">Id of Feedback</param>
        /// <param name="request">Feedback information update</param>
        /// <returns>Response</returns>
        [HttpPut("answer/{id:int}")]
        public async Task<IActionResult> PutAnswerFeedback(int id, [FromForm] FeedbackAnswerDTO request)
        {
            return HandleResult(await feedbackService.UpdateAnswerFeedbackAsync(id, request), LmsAction.Update);
        }

    }
}

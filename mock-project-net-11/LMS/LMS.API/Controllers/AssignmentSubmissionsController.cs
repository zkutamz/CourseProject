using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.AssignmentSubmissionsDTOs;
using LMS.Model.Request.CommonDTOs;
using LMS.Service.Services.AssignmentSubmissionServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSubmissionsController : BaseController
    {
        private readonly IAssignmentSubmissionServices _assignmentSubmissionServices;
        private readonly ILogger<AssignmentSubmissionsController> _logger;

        public AssignmentSubmissionsController(IAssignmentSubmissionServices assignmentSubmissionServices,
          ILogger<AssignmentSubmissionsController> logger)
        {
            _assignmentSubmissionServices = assignmentSubmissionServices;
            _logger = logger;
        }
        /// <summary>
        /// After completed the assignment, Create assignment submission to save result.
        /// </summary>
        /// <param name="assignmentSubmissionsCreateDTO">AssignmentSubmissionsCreateDTO</param>
        /// <returns>true:success false: failed</returns>
        [HttpPost("create-assignment-submission")]
        [Consumes("multipart/form-data")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> CreateAssignmentSubmissions([FromForm] AssignmentSubmissionsCreateDTO assignmentSubmissionsCreateDTO)
        {
            try
            {
                var result = await _assignmentSubmissionServices.CreateAssignmentSubmission(assignmentSubmissionsCreateDTO);
                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Assignment Submissions in API");
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// Check Assignment Submission to confirm user completed the assignment of Section.
        /// </summary>
        /// <param name="checkStatusStudyDTO">CheckStatusStudyDTO</param>
        /// <returns>true: completed 
        ///          false: inprogress</returns>
        [HttpGet("check-assignment-submission-completed")]
        public async Task<IActionResult> CheckAssignmentSubmissionCompleted([FromQuery] CheckStatusStudyDTO checkStatusStudyDTO)
        {
            try
            {
                var result = await _assignmentSubmissionServices.CheckAssignmentSubmissionCompleted(checkStatusStudyDTO);
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Check Assignment Submission Completed in API");
                throw new BadRequestException(ex.Message);
            }
        }
    }
}

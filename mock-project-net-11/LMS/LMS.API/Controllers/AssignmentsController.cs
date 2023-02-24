using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.AssignmentDTOs;
using LMS.Model.Response.AssignmentDTOs;
using LMS.Model.Utilities;
using LMS.Service.Services.AssignmentServices;
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
    public class AssignmentsController : BaseController
    {
        private readonly IAssignmentServices _assignmentServices;
        private readonly ILogger<AssignmentsController> _logger;
        private readonly ActionOptions _actionOptions;

        public AssignmentsController(
           IAssignmentServices assignmentServices,
           ILogger<AssignmentsController> logger, IOptionsSnapshot<ActionOptions> actionOptions)
        {
            _assignmentServices = assignmentServices;
            _logger = logger;
            _actionOptions = actionOptions.Value;
        }

        /// <summary>
        /// Get assignment details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult<AssignmentDetailDTO>>> GetAssignmentDetails(int id)
        {
            try
            {
                var assignmentDetailDTO = await _assignmentServices.GetAssignmentDetailAsync(id);
                return HandleResult(assignmentDetailDTO, _actionOptions.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetAssignmentDetails));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create assignment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<AssignmentDTO>>> CreateAssignment(AssignmentCreateDTO request)
        {
            try
            {
                var assignmentDTO = await _assignmentServices.CreateAssignmentAsync(request);

                return HandleResult(assignmentDTO, _actionOptions.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateAssignment));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Update assignment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<bool>>> UpdateAssignment(int id, [FromForm] AssignmentEditDTO request)
        {
            try
            {
                return HandleResult(await _assignmentServices.UpdateAssignmentAsync(id, request), _actionOptions.Update);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateAssignment));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Delete assignment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<bool>>> DeleteAssignment(int id)
        {
            try
            {
                return HandleResult(await _assignmentServices.DeleteAssignmentAsync(id), _actionOptions.Delete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteAssignment));
                throw new BadRequestException(ex.Message);
            }
        }
    }
}

using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Request.SectionDTOs;
using LMS.Model.Response.SectionDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.CourseService;
using LMS.Service.Services.SectionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionsController : BaseController
    {
        private readonly ISectionService _sectionService;
        private readonly ICourseService _courseService;
        private readonly ActionOptions _actionOptions;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly ILogger<SectionsController> _logger;

        public SectionsController(
            ISectionService sectionService,
            IOptionsSnapshot<ActionOptions> actionOptions,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            ILogger<SectionsController> logger,
            ICourseService courseService)
        {
            _sectionService = sectionService;
            _actionOptions = actionOptions.Value;
            _responseMessage = responseMessage.Value;
            _logger = logger;
            _courseService = courseService;
        }

        /// <summary>
        /// This action method is for getting a list of sections
        /// </summary>
        /// <param name="pagingRequest">Paging object</param>
        /// <returns>A list of Section DTOs</returns>
        /// <response code="200">If success</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagingResult<SectionDTO>>> Get([FromQuery] PagingRequest pagingRequest = null)
        {
            try
            {
                pagingRequest ??= new PagingRequest();

                var sections = await _sectionService.GetSectionDTOsAsync(pagingRequest);

                return Ok(sections);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(Get));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }

        /// <summary>
        /// Gets a section base on it ID
        /// </summary>
        /// <param name="id">ID of a section</param>
        /// <returns></returns>
        /// <response code="200">If success</response>
        /// <response code="400">If the provided ID is invalid</response>
        /// <response code="404">If there is no section found with the provided ID</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SectionDetailDTO>> Get(int id)
        {
            try
            {
                var section = await _sectionService.GetSectionDetailDTOAsync(id);

                if (section is null) return NotFound(_responseMessage.NotFound);

                return Ok(section);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(Get));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }

        /// <summary>
        /// This action method is for creating a new section into the DB
        /// </summary>
        /// <remarks>The instructor ID will be extracted from the auth token</remarks>
        /// <param name="request">A section create DTO</param>
        /// <returns>A section DTO object</returns>
        /// <response code="201">If success</response>
        /// <response code="400">If the provided course ID is invalid</response>
        /// <response code="401">If not login</response>
        /// <response code="404">If there is no course found with the provided course ID</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpPost]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<SectionDTO>> CreateSection(SectionCreateDTO request)
        {
            try
            {
                if (!await _courseService.IsExistsAsync(request.CourseId))
                    return NotFound(_responseMessage.NotFound);

                var sectionDTO = await _sectionService.CreateSectionAsync(request);

                if (sectionDTO is null) return BadRequest(_responseMessage.AddFailure);

                return CreatedAtRoute(null, sectionDTO);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateSection));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }

        /// <summary>
        /// This action method is for updating an existing section in the DB
        /// </summary>
        /// <remarks>The instructor ID will be extracted from the auth token</remarks>
        /// <param name="request">Section edit DTO</param>
        /// <returns>Success: true | Fail: false</returns>
        /// <response code="204">If success</response>
        /// <response code="400">If the update process fails</response>
        /// <response code="401">If not login</response>
        /// <response code="404">If there is no section or course found with the provided Ids</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpPut]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> UpdateSection(SectionEditDTO request)
        {
            try
            {
                if (!await _courseService.IsExistsAsync(request.CourseId) || !await _sectionService.IsExistsAsync(request.Id))
                    return NotFound(_responseMessage.NotFound);

                var result = await _sectionService.UpdateSectionAsync(request);

                if (result is false) return BadRequest(_responseMessage.UpdateFailure);

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(UpdateSection));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }

        /// <summary>
        /// This action method is for deleting an existing section in the DB.
        /// </summary>
        /// <remarks>The instructor ID will be extracted from the auth token</remarks>
        /// <param name="id">ID of type int</param>
        /// <returns>Success: true | Fail: false</returns>
        /// <response code="204">If success</response>
        /// <response code="400">If the update process fails</response>
        /// <response code="401">If not login</response>
        /// <response code="404">If there is no section or course found with the provided Ids</response>
        /// <response code="500">If there is an error with the server</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<bool>> DeleteSection(int id)
        {
            try
            {
                if (!await _sectionService.IsExistsAsync(id))
                    return NotFound(_responseMessage.NotFound);

                var result = await _sectionService.DeleteSectionAsync(id);

                if (result is false) return BadRequest(_responseMessage.DeleteFailure);

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(UpdateSection));
                return StatusCode(500, _responseMessage.ErrorOccurred);
            }
        }
    }
}
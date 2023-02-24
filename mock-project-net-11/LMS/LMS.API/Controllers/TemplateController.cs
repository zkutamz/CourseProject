using LMS.Model.Constant;
using LMS.Model.Request.TemplateDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.TemplateServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : BaseController
    {
        private readonly ITemplateService _templateService;
        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }
        // GET: api/<TemplateController>
        /// <summary>
        /// This Api will return a list of Template Detail and it paging
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>List paging of detail; Status code 404 if template does not exist</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTemplate([FromQuery] PagingRequest pagingRequest)
        {
            var result = await _templateService.GetTemplatesAsync(pagingRequest);
            return HandleResult(result, LmsAction.Get);
        }

        // GET api/<TemplateController>/5
        /// <summary>
        /// This API will return a Template detail
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>Status code 200 :Template if success; Stuscode 404 if template does not exist</returns>
        [HttpGet("{templateId}")]
        public async Task<IActionResult> GetTemplate(int templateId)
        {
            var result = await _templateService.GetTemplateAsync(templateId);
            return HandleResult(result, LmsAction.Get);
        }

        // POST api/<TemplateController>
        /// <summary>
        /// This API will add new Template
        /// </summary>
        /// <param name="templateCreateDTO"></param>
        /// <returns>Stutus code 200 if success, Status code 400 if have bad requet; Status code 409 if conflict</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTemplate([FromForm] TemplateCreateDTO templateCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _templateService.CreateTemplateAsync(templateCreateDTO);
            return HandleResult(result, LmsAction.Add);
        }

        // PUT api/<TemplateController>/5
        /// <summary>
        /// This API will update existed template in database 
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="templateEditDTO"></param>
        /// <returns>Status code 200 if success; Status code 409 if conflict in database; Status code 400 if values invalid; Status code 404 if template want to update does not exist </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTemplte(int templateId, [FromForm] TemplateEditDTO templateEditDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _templateService.UpdateTemplateAsync(templateId, templateEditDTO);
            return HandleResult(result, LmsAction.Update);
        }

        // DELETE api/<TemplateController>/5
        /// <summary>
        /// This API will soft delele  template by change it status in database
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>Status code 200 if success; Status code 404 if not found template</returns>
        [HttpPut("{templateId}")]
        public async Task<IActionResult> DeleteTemplate(int templateId)
        {
            var result = await _templateService.SoftDeleteTemplateAsync(templateId);
            return HandleResult(result, LmsAction.Delete);
        }
    }
}

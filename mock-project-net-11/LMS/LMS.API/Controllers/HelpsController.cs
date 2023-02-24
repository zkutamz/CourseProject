using LMS.Model.Constant;
using LMS.Model.Request.HelpArticleDTOs;
using LMS.Model.Request.HelpDTOs;
using LMS.Model.Request.HelpTopicDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.HelpArticleServices;
using LMS.Service.Services.HelpServices;
using LMS.Service.Services.HelpTopicServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Roles.ADMIN)]
    public class HelpsController : BaseController
    {
        private readonly IHelpService _helpService;
        private readonly IHelpTopicService _helpTopicService;
        private readonly IHelpArticleService _helpArticleService;

        public HelpsController(IHelpService helpService, IHelpTopicService helpTopicService, IHelpArticleService helpArticleService)
        {
            _helpService = helpService;
            _helpTopicService = helpTopicService;
            _helpArticleService = helpArticleService;
        }

        /// <summary>
        /// Get Help by userContent
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HelpDTO</returns>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetHelpDetail(int id)
        {
            return HandleResult(await _helpService.GetHelpDetail(id), LmsAction.Get);
        }

        /// <summary>
        /// Get list all help
        /// </summary>
        /// <returns>List HelpDTO</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllHelp()
        {
            return HandleResult(await _helpService.GetAllHelp(), LmsAction.Get);
        }

        /// <summary>
        /// Get list all help is published
        /// </summary>
        /// <returns>List HelpDTO</returns>
        [HttpGet]
        [Route("published")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllHelpPublished()
        {
            return HandleResult(await _helpService.GetAllHelpPublished(), LmsAction.Get);
        }

        /// <summary>
        /// Create new help
        /// </summary>
        /// <param name="helpCreate"></param>
        /// <returns>New helpId</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateHelp(HelpCreateDTO helpCreate)
        {
            return HandleResult(await _helpService.CreateHelp(helpCreate), LmsAction.Add);
        }

        /// <summary>
        /// Update help
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpEdit"></param>
        /// <returns>True if success</returns>
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateHelp(int id, HelpEditDTO helpEdit)
        {
            return HandleResult(await _helpService.UpdateHelp(id, helpEdit), LmsAction.Update);
        }

        /// <summary>
        /// Delete help
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteHelp(int id)
        {
            return HandleResult(await _helpService.DeleteHelp(id), LmsAction.Delete);
        }


        /// <summary>
        /// Get Topic Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HelpTopicDetailDTO</returns>
        [HttpGet]
        [Route("topic/{id}")]
        public async Task<IActionResult> GetTopicDetail(int id)
        {
            return HandleResult(await _helpTopicService.GetTopicDetail(id), LmsAction.Get);
        }

        /// <summary>
        /// Create new help topic
        /// </summary>
        /// <param name="helpTopicCreate"></param>
        /// <returns>New helpTopicId</returns>
        [HttpPost]
        [Route("topic")]
        public async Task<IActionResult> CreateTopic(HelpTopicCreateDTO helpTopicCreate)
        {
            return HandleResult(await _helpTopicService.CreateHelpTopic(helpTopicCreate), LmsAction.Add);
        }

        /// <summary>
        /// Update help topic
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpTopicEdit"></param>
        /// <returns>True if success</returns>
        [HttpPut]
        [Route("topic/{id}")]
        public async Task<IActionResult> UpdateTopic(int id, HelpTopicEditDTO helpTopicEdit)
        {
            return HandleResult(await _helpTopicService.UpdateHelpTopic(id, helpTopicEdit), LmsAction.Update);
        }

        /// <summary>
        /// Delete help topic
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        [HttpDelete]
        [Route("topic/{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            return HandleResult(await _helpTopicService.DeleteHelpTopic(id), LmsAction.Delete);
        }

        #region Article
        /// <summary>
        /// Get Article Detail
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>HelpArticleDetailDTO</returns>
        [HttpGet]
        [Route("article/{id}")]
        public async Task<IActionResult> GetArticleDetail(int id)
        {
            return HandleResult(await _helpArticleService.GetArticleDetail(id), LmsAction.Get);
        }

        /// <summary>
        /// Get All Article By Topic
        /// </summary>
        /// <param name="HelpTopicId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List HelpArticleDTO </returns>
        [HttpGet]
        [Route("article")]
        public async Task<IActionResult> GetAllArticle(int HelpTopicId, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _helpArticleService.GetAllArticle(HelpTopicId, pagingRequest), LmsAction.Get);
        }
        /// <summary>
        /// Get All Article for topic help
        /// </summary>
        /// <param name="HelpTopicId">HelpTopicId</param>
        /// <returns>List HelpArticleDTO</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("all-article")]
        public async Task<IActionResult> GetAllArticle(int HelpTopicId)
        {
            return HandleResult(_helpArticleService.GetAllArticle(HelpTopicId), LmsAction.Get);
        }
        /// <summary>
        /// Delete Article By Id
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns>bool</returns>
        [HttpDelete]
        [Route("article/{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            return HandleResult(await _helpArticleService.DeleteHelpArticle(id), LmsAction.Delete);
        }

        /// <summary>
        /// Edit article 
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="helpArticleDTO"></param>
        /// <returns>bool</returns>
        [HttpPut]
        [Route("article/{id}")]
        public async Task<IActionResult> EditArticle(int id, [FromForm] HelpArticleEditDTO helpArticleDTO)
        {
            return HandleResult(await _helpArticleService.UpdateHelpArticle(id, helpArticleDTO), LmsAction.Update);
        }

        /// <summary>
        /// Add Article
        /// </summary>
        /// <param name="helpArticleCreateDTO"></param>
        /// <returns>HelpArticleDTO</returns>
        [HttpPost]
        [Route("article")]
        public async Task<IActionResult> AddArticle([FromForm] HelpArticleCreateDTO helpArticleCreateDTO)
        {
            return HandleResult(await _helpArticleService.CreateHelpArticle(helpArticleCreateDTO), LmsAction.Add);
        }
        /// <summary>
        /// Search for help articles
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("search/{keyword}")]
        public async Task<IActionResult> GetHeplSearch(string keyword, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _helpArticleService.GetHelpSearch(keyword, pagingRequest), LmsAction.Get);
        }
        #endregion
    }
}

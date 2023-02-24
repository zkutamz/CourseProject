using LMS.API.Extensions;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.DiscussionDTOs;
using LMS.Model.Request.ReactDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.DiscussionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiscussionsController : BaseController
    {
        private readonly IDiscussionService _discussionService;

        public DiscussionsController(IDiscussionService discussionService)
        {
            _discussionService = discussionService;
        }

        /// <summary>
        /// Add discussion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(DiscussionCreateDTO request)
        {
            try
            {
                await _discussionService.AddAsync(User.GetUserId(), request);
                return HandleResult(Ok(), LmsAction.Add);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e}");
            }
        }

        /// <summary>
        /// Update discussion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, DiscussionEditDTO request)
        {
            try
            {
                await _discussionService.UpdateAsync(id, request);
                return HandleResult(Ok(), LmsAction.Update);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.Message}");
            }
        }

        /// <summary>
        /// Get discussion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await _discussionService.GetAsync(id);
                return HandleResult(Ok(model), LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.Message}");
            }
        }

        /// <summary>
        /// Delete discussion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _discussionService.DeleteAsync(id);
                return HandleResult(Ok(), LmsAction.Delete);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.Message}");
            }
        }

        /// <summary>
        /// Get discussions
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("{authorId}/paging")]
        public async Task<IActionResult> GetAll([FromQuery] PagingRequest pagingRequest, int authorId)
        {
            try
            {
                var models = await _discussionService.GetAllAsync(authorId, pagingRequest);
                return HandleResult(Ok(models), LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.Message}");
            }
        }

        /// <summary>
        /// React discussion (like or dislike)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("react")]
        public async Task<IActionResult> React(ReactCreateDTO request)
        {
            try
            {
                await _discussionService.ReactAsync(User.GetUserId(), request);
                return HandleResult(Ok(), LmsAction.Add);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong. {e.Message}");
            }
        }
    }
}

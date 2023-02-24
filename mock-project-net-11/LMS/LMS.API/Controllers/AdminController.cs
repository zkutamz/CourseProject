using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.AppUserDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = Roles.ADMIN)]
    public class AdminController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IUserService userService, ILogger<AdminController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Change block status of user
        /// </summary>
        /// <param name="status"></param>
        /// <returns>True if success</returns>
        [HttpPut]
        [Route("block-status")]
        public async Task<IActionResult> ChangeBlockUser(AppUserBlockStatusDTO status)
        {
            return HandleResult<bool>(await _userService.ChangeUserBlockStatus(status), LmsAction.Update);
        }
        /// <summary>
        /// Get all user 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [Authorize(Roles = Roles.ADMIN)]
        [HttpGet("user")]
        public async Task<ActionResult<PagingResult<AppUserDetailRoleDTO>>> GetAllUser([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var userResults = await _userService.GetAllPaged(pagingRequest);
                return HandleResult(userResults, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error GetAllUser in API");
                throw new BadRequestException(ex.Message);
            }

        }
        /// <summary>
        /// Create User 
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns>true if success</returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost("user")]
        public async Task<IActionResult> CreateUser([FromBody] AppUserCreateDTO userCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return HandleResult(await _userService.CreateUser(userCreateDto), LmsAction.Add);

        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("user/{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            if (user != null)
            {
                return HandleResult(user, LmsAction.Get);
            }
            return NotFound($"Not found User by id = {id}");
        }

        /// <summary>
        /// Update user infor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userEdit"></param>
        /// <returns>True if success</returns>
        [HttpPut]
        [Route("user/{id}")]
        public async Task<IActionResult> UpdateUserInfor(int id, AppUserEditDTO userEdit)
        {
            return HandleResult(await _userService.UpdateInforAsync(id, userEdit), LmsAction.Update);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        [HttpDelete]
        [Route("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return HandleResult(await _userService.DeleteUser(id), LmsAction.Delete);
        }

        /// <summary>
        /// Assign role to user
        /// </summary>
        /// <param name="assignRole"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("assign-role")]
        public async Task<IActionResult> AssignUserRole(AppUserAssignRoleDTO assignRole)
        {
            return HandleResult(await _userService.AssignRole(assignRole), LmsAction.Update);
        }

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appUserChangePassword"></param>
        /// <returns>True if success and false if fail</returns>
        [HttpPut]
        [Route("change-password/user/{id}")]
        public async Task<IActionResult> ChangeUserPassword(int id, AppUserChangePasswordDTO appUserChangePassword)
        {
            return HandleResult(await _userService.ChangeUserPassword(id, appUserChangePassword), LmsAction.Update);
        }
    }
}

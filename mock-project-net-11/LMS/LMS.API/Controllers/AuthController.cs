using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.ForgotPasswordDTOs;
using LMS.Model.Request.LoginDTOs;
using LMS.Model.Request.RegisterDTOs;
using LMS.Model.Request.ResetPasswordDTOs;
using LMS.Model.Request.VerifyDTOs;
using LMS.Service.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Login into system
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                return HandleResult(await _authService.LoginAsync(request), LmsAction.Add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Register account in system
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                return HandleResult(await _authService.RegisterAsync(request, Request.Headers["origin"]), LmsAction.Add);
            }

            throw new BadRequestException(ModelState.Select(x => x.Value).ToString());
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <returns>string: new access token</returns>
        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            try
            {
                return HandleResult(await _authService.RefreshToken(), LmsAction.Add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// revoke refresh token
        /// </summary>
        /// <returns> true: success</returns>
        [Authorize]
        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken()
        {
            try
            {
                return HandleResult(await _authService.RevokeToken(), LmsAction.Add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        /// <summary>
        /// verify email
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] string token)
        {
            try
            {
                return HandleResult(await _authService.VerifyEmail(token), LmsAction.Add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            try
            {
                return HandleResult(await _authService.ForgotPassword(model.EmailAddress, Request.Headers["origin"]), LmsAction.Add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        /// <summary>
        /// reset-password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            try
            {
                return HandleResult(await _authService.ResetPassword(model), LmsAction.Add);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
    }
}

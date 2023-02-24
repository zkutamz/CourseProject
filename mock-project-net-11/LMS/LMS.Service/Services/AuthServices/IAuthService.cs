using LMS.Model.Request.LoginDTOs;
using LMS.Model.Request.RegisterDTOs;
using LMS.Model.Request.ResetPasswordDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.AuthenticationDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.AuthServices
{
    public interface IAuthService
    {
        /// <summary>
        /// User login
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string: access token</returns>
        Task<AuthenticationResponse> LoginAsync(LoginRequest request);
        /// <summary>
        /// user register 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>AppUserDTO</returns>
        Task<AppUserDTO> RegisterAsync(RegisterRequest request, string origin);
        /// <summary>
        /// Verify Email
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns>true: success, false: failure</returns>
        Task<bool> VerifyEmail(string token);
        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="origin"></param>
        /// <returns>tru:success</returns>
        Task<bool> ForgotPassword(string email, string origin);
        Task<bool> ResetPassword(ResetPasswordRequest model);
        #region Token
        /// <summary>
        /// refresh token
        /// </summary>
        /// <returns>string: new access token</returns>
        Task<AuthenticationResponse> RefreshToken();
        /// <summary>
        /// Revoke token
        /// </summary>
        /// <returns>true: success</returns>
        Task<bool> RevokeToken();
        #endregion
    }
}

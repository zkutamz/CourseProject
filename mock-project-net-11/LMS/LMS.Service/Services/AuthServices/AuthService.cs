using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.LoginDTOs;
using LMS.Model.Request.RegisterDTOs;
using LMS.Model.Request.ResetPasswordDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.AuthenticationDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using LMS.Service.Options;
using LMS.Service.Services.EmailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserAccessor _userAccessor;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly IEmailService _emailService;

        public AuthService(
            IUnitOfWork unitOfWork,
            ILogger<AuthService> logger,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IMapper mapper,
            SignInManager<AppUser> signInManager,
            IHttpContextAccessor httpContextAccessor,
            IUserAccessor userAccessor,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            IOptionsSnapshot<JwtTokenOptions> jwtTokenOptions,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _userAccessor = userAccessor;
            _responseMessage = responseMessage.Value;
            _jwtTokenOptions = jwtTokenOptions.Value;
        }
        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(request.Email));
            }

            var result = await _signInManager.PasswordSignInAsync(request.Email,
                request.Password, request.Remember, lockoutOnFailure: true);
            var userDto = _mapper.Map<AppUserDTO>(user);
            var roles = await _userManager.GetRolesAsync(user);

            if (result.Succeeded)
            {
                var jwtToken = await GenerateJsonWebTokenAsync(user);
                var refreshToken = await CreateRefreshToken(user, request.Remember);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                };

                _httpContextAccessor.HttpContext!.Response.Cookies.Append("refreshToken", refreshToken.Token!, cookieOptions);
                return new AuthenticationResponse
                {
                    Token = jwtToken,
                    User = userDto,
                    Roles = string.Join(',', roles),
                    Expires = DateTime.Now.AddMilliseconds(_jwtTokenOptions.Expires)
                };
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                throw new BadRequestException("User account locked out.");
            }
            else if (result.IsNotAllowed)
            {
                _logger.LogWarning("Please verify your email before logging in.");
                throw new BadRequestException("Please verify your email before logging in.");
            }
            else
            {
                _logger.LogWarning("The email or password was wrong.");
                throw new BadRequestException("The email or password was wrong.");
            }
        }

        public async Task<AppUserDTO> RegisterAsync(RegisterRequest request, string origin)
        {
            using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user != null)
                {
                    throw new BadRequestException(ResponseMessage.OBJECT_EXIST(request.Email));
                }

                user = new AppUser()
                {
                    UserName = request.Email,
                    Email = request.Email,
                    NormalizedEmail = request.Email.ToUpper(),
                    NormalizedUserName = request.Email.ToUpper(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    VerificationToken = randomTokenString()
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var userFromDb = await _userManager.FindByEmailAsync(request.Email);
                    await _userManager.AddToRoleAsync(userFromDb, request.Type);
                    await sendVerificationEmail(userFromDb, origin);

                    await trans.CommitAsync();
                    return _mapper.Map<AppUserDTO>(user);
                }

                throw new BadRequestException(result.Errors.FirstOrDefault()?.Description);
            }
            catch (Exception e)
            {
                await trans.RollbackAsync();
                _logger.LogError($"Something went wrong in {nameof(RegisterAsync)}. {e.Message}");
                throw new BadRequestException(e.Message);
            }

        }


        public async Task<AuthenticationResponse> RefreshToken()
        {
            var refreshToken = _httpContextAccessor.HttpContext!.Request.Cookies["refreshToken"];

            var userId = await _userAccessor.GetUserId();

            var user = await _unitOfWork.AppUserRepository.GetAsync(x => x.Id == userId);

            if (user == null) throw new AuthorizedException("User");

            var oldToken = user.UserLoginTokens!.SingleOrDefault(x => x.Token == refreshToken);

            if (oldToken != null && !oldToken.IsActive) throw new AuthorizedException("");

            var jwt = await GenerateJsonWebTokenAsync(user);

            return new AuthenticationResponse
            {
                Token = jwt,
                Expires = DateTime.Now.AddMilliseconds(_jwtTokenOptions.Expires)
            };
        }


        public async Task<bool> RevokeToken()
        {
            using var tranasction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var refreshTokenFromDB = await getRefreshToken();
                refreshTokenFromDB.Revoked = DateTime.UtcNow;
                await _unitOfWork.UserLoginTokenRepository.UpdateAsync(refreshTokenFromDB);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if (!isSave) throw new Exception(ResponseMessage.UpdateFailure);
                await tranasction.CommitAsync();
                return isSave;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await tranasction.RollbackAsync();
                throw;
            }


        }

        public async Task<bool> VerifyEmail(string token)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var appUserFromDb = await _unitOfWork.AppUserRepository.GetAsync(x => x.VerificationToken == token);
                if (appUserFromDb == null) throw new Exception("Verification failed");
                appUserFromDb.EmailConfirmed = true;
                await _unitOfWork.AppUserRepository.UpdateAsync(appUserFromDb);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if (!isSave) throw new Exception(ResponseMessage.UpdateFailure);
                await transaction.CommitAsync();
                return isSave;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<bool> ForgotPassword(string email, string origin)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var appUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.Email == email);
                if (appUser == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(email));
                appUser.ResetToken = randomTokenString();
                appUser.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

                await _unitOfWork.AppUserRepository.UpdateAsync(appUser);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if (!isSave) throw new Exception(ResponseMessage.UpdateFailure);
                await sendPasswordResetEmail(appUser, origin);
                await transaction.CommitAsync();
                return isSave;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }


        public async Task<bool> ResetPassword(ResetPasswordRequest model)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var appUser = await _unitOfWork.AppUserRepository
                        .GetAsync(x =>
                            x.ResetToken == model.TokenReset
                            && x.ResetTokenExpires > DateTime.UtcNow);
                if (appUser == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(model.Email));
                var hasher = new PasswordHasher<AppUser>();
                appUser.PasswordHash = hasher.HashPassword(null, model.Password);
                appUser.PasswordReset = DateTime.UtcNow;
                appUser.ResetToken = null;
                appUser.ResetTokenExpires = null;
                await _unitOfWork.AppUserRepository.UpdateAsync(appUser);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if (!isSave) throw new Exception(ResponseMessage.UpdateFailure);
                await transaction.CommitAsync();
                return isSave;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        #region Set Up Token
        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
        private async Task<UserLoginToken> CreateRefreshToken(AppUser appUser, bool remember)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var refreshToken = GenerateRefreshToKen(remember);

                appUser.UserLoginTokens!.Add(refreshToken);

                await _unitOfWork.AppUserRepository.UpdateAsync(appUser!);
                await transaction.CommitAsync();
                await _unitOfWork.SaveAsync();

                return refreshToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
        private UserLoginToken GenerateRefreshToKen(bool remember)
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            var refreshToken = new UserLoginToken
            {
                Token = Convert.ToBase64String(randomNumber)
            };

            if (!remember)
            {
                refreshToken.Expires = DateTime.UtcNow.AddHours(1);
            }

            return refreshToken;
        }
        private async Task<UserLoginToken> getRefreshToken()
        {
            var userId = await _userAccessor.GetUserId();
            var userLoginTokens = await _unitOfWork.UserLoginTokenRepository
                .GetAllAsyncNoPaging(userToken => userToken.AppUserId == userId);
            var user = userLoginTokens.SingleOrDefault(u => u.IsActive == true);
            if (user == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(userId.ToString()));
            return user;
        }
        private async Task<string> GenerateJsonWebTokenAsync(AppUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claim = await GetAllValidClaimAsync(user);

            var token = new JwtSecurityToken(
                _jwtTokenOptions.Issuer,
                _jwtTokenOptions.Issuer,
                claim,
                expires: DateTime.Now.AddMinutes(_jwtTokenOptions.Expires),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<List<Claim>> GetAllValidClaimAsync(AppUser user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //Getting claims that we have assigned to the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            //Get the user role and add it to the claims
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }

        #endregion

        #region Send Email

        private async Task sendPasswordResetEmail(AppUser appUser, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/reset-password?token={appUser.ResetToken}";
                message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
                             <p><code>{appUser.ResetToken}</code></p>";
            }

            await _emailService.SenderEmailAsync(
                to: appUser.Email,
                subject: "Sign-up Verification API - Reset Password",
                html: $@"<h4>Reset Password Email</h4>
                         {message}"
            );
        }
        private async Task sendVerificationEmail(AppUser appUser, string origin)
        {
            string msg;
            var token = appUser.VerificationToken;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/verify-email?token={token}";
                msg = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                msg = $@"<p>Please use the below token to verify your email address with the <code>/Auth/verify-email</code> api route:</p>
                             <p><code>{token}</code></p>";
            }

            await _emailService.SenderEmailAsync(
                to: appUser.Email,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {msg}"
            );
        }

        #endregion


    }
}

using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.AppUserDTOs;
using LMS.Model.Request.RegisterDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CourseCommentDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using LMS.Service.Services.FileStorageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly IFileStorageService _fileStorageService;

        public UserService(
            IUnitOfWork unitOfWork,
            ILogger<UserService> logger,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IMapper mapper,
            IFileStorageService fileStorageService,
            IHttpContextAccessor httpContextAccessor,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _fileStorageService = fileStorageService;
            _fileStorageService = fileStorageService;
            _responseMessage = responseMessage.Value;
            _userAccessor = userAccessor;
        }

        /// <summary>
        /// Change block status of user, if lock will lockend in 1000 years
        /// </summary>
        /// <param name="status"></param>
        /// <returns>True if success</returns>
        public async Task<bool> ChangeUserBlockStatus(AppUserBlockStatusDTO status)
        {
            try
            {
                await using var transaction = await _unitOfWork.BeginTransactionAsync();
                var user = await _unitOfWork.AppUserRepository.GetAsync(a => a.Id == status.Id);
                if (user == null)
                    throw new BadRequestException(ResponseMessage.GetDataFailed);
                user.LockoutEnabled = status.Status;
                user.LockoutEnd = status.Status == true ? DateTime.Now.AddYears(1000) : DateTime.Now;
                await _unitOfWork.AppUserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(ChangeUserBlockStatus));
                throw;
            }
        }
        public async Task<bool> CreateUser(AppUserCreateDTO userModel)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = _mapper.Map<AppUserCreateDTO, AppUser>(userModel);

                var userResult = await _userManager.CreateAsync(user, userModel.Password);
                var userRole = new AppUserAssignRoleDTO();
                userRole.UserId = user.Id;
                userRole.RoleId = userModel.RoleId;

                
                if (!userResult.Succeeded)
                {
                    string messageError = String.Empty;
                    foreach (var item in userResult.Errors)
                    {
                        messageError = messageError + item.Description;
                    }
                    throw new BadRequestException(messageError);
                }
                var result = await AssignRole(userRole);
                
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateUser));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<AppUserDetailRoleDTO>> GetAllInstructorUser()
        {
            try
            {
                var users = await _unitOfWork.AppUserRepository.GetAllAsyncNoPaging();
                var mapUsers = _mapper.Map<List<AppUser>, List<AppUserDetailRoleDTO>> (users);
                var listUser = new List<AppUserDetailRoleDTO>();
                foreach (var user in mapUsers)
                {
                    var role = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id.ToString()));
                    if(role.Contains(Roles.INSTRUCTOR))
                    {
                        user.RoleName = string.Join(',', role);
                        listUser.Add(user);
                    }
                }

                /*var paginResult = new PagingResult<AppUserDetailRoleDTO>()
                {
                    TotalCount = users.TotalCount,
                    TotalPages = users.TotalPages,
                    PageSize = users.PageSize,
                    CurrentPage = users.CurrentPage,
                    Objects = listUser
                };*/

                return listUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetAllInstructorUser));
                throw;
            }
        }

        public async Task<AppUserDetailRoleDTO> GetById(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.AppUserRepository.GetAsync(s => s.Id == id);

                if (user == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(id.ToString()));
                }

                var loggedInUserId = await _userAccessor.GetUserId();

                if (loggedInUserId != id)
                {
                    user.ProfileViewCount++;
                    var result = await _unitOfWork.AppUserRepository.UpdateAsync(user);

                    if (result)
                    {
                        await _unitOfWork.SaveAsync();
                        await transaction.CommitAsync();
                    }
                }
                var mapUsers = _mapper.Map<AppUser,AppUserDetailRoleDTO>(user);
                mapUsers.RoleName = string.Join(',', await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id.ToString())));
                

                return mapUsers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetById));
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<AppUserDTO> CreateAsync(RegisterRequest request)
        {
            using (var trans = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var user = new AppUser()
                    {
                        Email = request.Email,
                        LastName = request.LastName,
                        UserName = request.Email,
                        NormalizedEmail = request.Email.ToUpper(),
                        NormalizedUserName = request.Email.ToUpper()
                    };
                    var result = await _userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, Roles.STUDENT);
                        await _unitOfWork.SaveAsync();
                        await trans.CommitAsync();
                        return _mapper.Map<AppUserDTO>(user);
                    }

                    _logger.LogError($"Has an error when create user. " +
                                     $"{result.Errors.Select(x => x.Description).ToList()}");
                    throw new Exception(result.Errors.FirstOrDefault()?.Description);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Has an error when create user. {e.Message}");
                    await trans.RollbackAsync();
                    throw;
                }
            }

        }

        public async Task<int> GetTotalCoursePurchaseAsync(int userId)
        {
            try
            {
                return await _unitOfWork.AppUserRepository.GetTotalCoursePurchaseAsync(userId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong!. {e.InnerException?.Message}");
                throw;
            }
        }

        public async Task<int> GetTotalReviewsAsync(int userId)
        {
            try
            {
                return await _unitOfWork.AppUserRepository.GetTotalReviewsAsync(userId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(GetTotalReviewsAsync)}!. {e.InnerException?.Message}");
                throw;
            }
        }

        public async Task<int> GetTotalSubscriptionsAsync(int userId)
        {
            try
            {
                return await _unitOfWork.AppUserRepository.GetTotalSubscriptionsAsync(userId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(GetTotalSubscriptionsAsync)}!. {e.InnerException?.Message}");
                throw;
            }
        }

        public async Task<int> GetTotalCertificatesAsync(int userId)
        {
            try
            {
                return await _unitOfWork.AppUserRepository.GetTotalCertificatesAsync(userId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(GetTotalCertificatesAsync)}!. {e.InnerException?.Message}");
                throw;
            }
        }

        public async Task<string> GetAboutMeAsync(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                return user.Intro ?? String.Empty;
            }

            throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(userId.ToString()));
        }

        public async Task<PaginatedList<PurchasedCoursesDTO>> GetPurchasedCoursesAsync(int userId, PagingRequest pagingRequest)
        {
            return _mapper.Map<PaginatedList<PurchasedCoursesDTO>>(await _unitOfWork.AppUserRepository.GetPurchasedCoursesAsync(userId, pagingRequest));
        }

        public async Task<PaginatedList<CourseCommentDTO>> GetDiscussionsAsync(int userId, PagingRequest pagingRequest)
        {
            return _mapper.Map<PaginatedList<CourseCommentDTO>>(await _unitOfWork.AppUserRepository.GetDiscussionsAsync(userId, pagingRequest));
        }

        public async Task<bool> UpdateAsync(int id, AppUserDTO user)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != user.Id)
                {
                    throw new BadRequestException(ResponseMessage.NotMatch);
                }

                var userDb = await _unitOfWork.AppUserRepository.GetAsync(a => a.Id == id);
                if (userDb == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(id.ToString()));
                }

                userDb.FirstName = user.FirstName;
                userDb.LastName = user.LastName;
                userDb.Headline = user.Headline;
                userDb.Intro = userDb.Intro;
                userDb.ProfileLink = userDb.ProfileLink;
                userDb.FacebookLink = userDb.FacebookLink;
                userDb.TwitterLink = userDb.TwitterLink;
                userDb.LinkedInLink = userDb.LinkedInLink;
                userDb.YoutubeLink = userDb.YoutubeLink;

                await _unitOfWork.AppUserRepository.UpdateAsync(userDb);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(UpdateAsync)}. {e}");
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<int> GetTotalInstructorsSubscribing(int studentId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = await _unitOfWork.AppUserRepository
                    .GetTotalInstrutorsSubscribingByStudent(studentId);

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return courseDTO;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Update user infor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userEdit"></param>
        /// <returns>True if success</returns>
        public async Task<bool> UpdateInforAsync(int id, AppUserEditDTO userEdit)
        {
            if (id != userEdit.Id) throw new BadRequestException(ResponseMessage.NotMatch);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == id);
                
                if (user == null) throw new BadRequestException(ResponseMessage.GetDataFailed);
                var assignRole = new AppUserAssignRoleDTO();
                assignRole.UserId = id;
                assignRole.RoleId = userEdit.RoleId;

                var userMap = _mapper.Map(userEdit, user);

                /*user.FirstName = userEdit.FirstName;
                user.LastName = userEdit.LastName;
                user.BirthDate = userEdit.BirthDate;
                user.ProfileImageUrl = userEdit.ProfileImageUrl;
                user.Intro = userEdit.Intro;
                user.PhoneNumber = userEdit.PhoneNumber;*/

                await _unitOfWork.AppUserRepository.UpdateAsync(userMap);
                var assignRoleResult = await AssignRole(assignRole);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateInforAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        public async Task<bool> DeleteUser(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == id);
                if (user == null) throw new BadRequestException(ResponseMessage.GetDataFailed);
                string userFileName = null;
                if (user.ProfileImageUrl != null)
                    userFileName = user.ProfileImageUrl;
                user.IsDelete = true;
                await _unitOfWork.AppUserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                if (userFileName != null)
                    await _fileStorageService.DeleteFileAsync(userFileName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteUser));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Assign role to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns>True if success</returns>
        public async Task<bool> AssignRole(AppUserAssignRoleDTO assignRole)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(assignRole.UserId.ToString());
                var role = await _roleManager.FindByIdAsync(assignRole.RoleId.ToString());
                if (user == null || role == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                var userRole = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRole);
                await _userManager.AddToRoleAsync(user, role.Name);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(AssignRole));
                throw;
            }
        }

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="appUserChangePassword"></param>
        /// <returns>True if success and false if fail</returns>
        public async Task<bool> ChangeUserPassword(int id, AppUserChangePasswordDTO appUserChangePassword)
        {
            if (id != appUserChangePassword.Id) throw new BadRequestException(ResponseMessage.NOT_MATCH);
            bool success = false;
            try
            {
                var user = await _userManager.FindByIdAsync(appUserChangePassword.Id.ToString());
                if (user == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                var changePass = await _userManager.ChangePasswordAsync(user, appUserChangePassword.OldPasswordHash, appUserChangePassword.PasswordHash);
                if (changePass.Succeeded)
                    success = true;
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteUser));
                throw;
            }
        }

        public async Task<bool> VoteAUserAsync(int id, bool isUpvote)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (id <= 0) throw new BadRequestException(_responseMessage.InvalidParameters);

                var user = await _unitOfWork.AppUserRepository.GetAsync(a => a.Id == id);

                if (user is null) throw new NotFoundException(_responseMessage.NotFound);

                var voterId = await _userAccessor.GetUserId();

                var userVoter = await _unitOfWork.UserVoterRepository
                    .GetAsync(u => u.UserId == id && u.VoterId == voterId);

                var userVoterUpdateResult = false;

                if (userVoter is null)
                {
                    // if isUpvote true then enter true in the isUpvote column
                    var newUserVoter = new UserVoter
                    {
                        UserId = id,
                        VoterId = voterId,
                        IsUpvote = isUpvote
                    };

                    if (isUpvote)
                        user.UpVote++;
                    else
                        user.DownVote++;

                    userVoterUpdateResult = await _unitOfWork.UserVoterRepository.AddAsync(newUserVoter);
                }
                else
                {
                    if (userVoter.IsUpvote)
                    {
                        if (!isUpvote)
                        {
                            user.UpVote--;
                            user.DownVote++;
                        }
                        else
                            throw new BadRequestException(_responseMessage.InvalidParameters);
                    }
                    else
                    {
                        if (isUpvote)
                        {
                            user.DownVote--;
                            user.UpVote++;
                        }
                        else
                            throw new BadRequestException(_responseMessage.InvalidParameters);
                    }

                    userVoter.IsUpvote = !userVoter.IsUpvote;

                    userVoterUpdateResult = await _unitOfWork.UserVoterRepository.UpdateAsync(userVoter);
                }

                var result = await _unitOfWork.AppUserRepository.UpdateAsync(user);

                if (result && userVoterUpdateResult)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(VoteAUserAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<AppUserDetailRoleDTO>> GetAllPaged(PagingRequest paging)
        {
            try
            {
                var users = await _unitOfWork.AppUserRepository.GetAllAsync(paging);
                var mapUsers = _mapper.Map<PaginatedList<AppUser>, PaginatedList<AppUserDetailRoleDTO>>(users);
                var listUser = new List<AppUserDetailRoleDTO>();
                foreach (var user in mapUsers)
                {
                    user.RoleName = string.Join(',', await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id.ToString())));
                    listUser.Add(user);
                }

                var paginResult = new PagingResult<AppUserDetailRoleDTO>()
                {
                    TotalCount = users.TotalCount,
                    TotalPages = users.TotalPages,
                    PageSize = users.PageSize,
                    CurrentPage = users.CurrentPage,
                    Objects = listUser
                };

                return paginResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetAllPaged));
                throw;
            }
        }
    }
}
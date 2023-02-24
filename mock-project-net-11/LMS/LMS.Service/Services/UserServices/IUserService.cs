using LMS.Model.Request.AppUserDTOs;
using LMS.Model.Request.RegisterDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CourseCommentDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.UserServices
{
    public interface IUserService
    {
        /// <summary>
        /// Change block status of user
        /// </summary>
        /// <param name="status"></param>
        /// <returns>True if success</returns>
        Task<bool> ChangeUserBlockStatus(AppUserBlockStatusDTO status);
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="userCreateModel"></param>
        /// <returns>true if success</returns>
        Task<bool> CreateUser(AppUserCreateDTO userCreateModel);
        Task<AppUserDetailRoleDTO> GetById(int id);
        /// <summary>
        /// Get all user async
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<List<AppUserDetailRoleDTO>> GetAllInstructorUser();
        Task<PagingResult<AppUserDetailRoleDTO>> GetAllPaged(PagingRequest paging);
        /// <summary>
        /// Create user async
        /// </summary>
        /// <param name="request"></param>
        /// <returns>AppUserDTO</returns>
        Task<AppUserDTO> CreateAsync(RegisterRequest request);
        Task<int> GetTotalCoursePurchaseAsync(int userId);
        Task<int> GetTotalReviewsAsync(int userId);
        Task<int> GetTotalSubscriptionsAsync(int userId);
        Task<int> GetTotalCertificatesAsync(int userId);
        Task<string> GetAboutMeAsync(int userId);
        Task<PaginatedList<PurchasedCoursesDTO>> GetPurchasedCoursesAsync(int userId, PagingRequest request);
        Task<PaginatedList<CourseCommentDTO>> GetDiscussionsAsync(int userId, PagingRequest pagingRequest);
        Task<bool> UpdateAsync(int id, AppUserDTO user);
        Task<int> GetTotalInstructorsSubscribing(int studentId);



        /// <summary>
        /// Update user infor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userEdit"></param>
        /// <returns>True if success</returns>
        Task<bool> UpdateInforAsync(int id, AppUserEditDTO userEdit);
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        Task<bool> DeleteUser(int id);

        /// <summary>
        /// Assign role to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns>True if success</returns>
        Task<bool> AssignRole(AppUserAssignRoleDTO assignRole);

        /// <summary>
        /// Change user password
        /// </summary>
        /// <param name="appUserChangePassword"></param>
        /// <returns>True if success and false if fail</returns>
        Task<bool> ChangeUserPassword(int id, AppUserChangePasswordDTO appUserChangePassword);

        /// <summary>
        /// Upvote a user or downvote a user. Each voters can either upvote or download.
        /// If already upvote then the vote will be switch to downvote and vice versa.
        /// </summary>
        /// <param name="id">ID of an user who got voted.</param>
        /// <param name="isUpvote"></param>
        /// <returns></returns>
        Task<bool> VoteAUserAsync(int id, bool isUpvote);
    }
}

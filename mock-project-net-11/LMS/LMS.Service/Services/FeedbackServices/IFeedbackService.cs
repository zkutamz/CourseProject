using LMS.Model.Request.FeedbackDTOs;
using LMS.Model.Response.FeedbackDTOs;
using LMS.Repository.Paging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Services.FeedbackServices
{
    public interface IFeedbackService
    {
        /// <summary>
        /// Service Create Feedback of User
        /// </summary>
        /// <param name="feedback">Feedback information create</param>
        /// <param name="screenShot">File screenShot</param>
        /// <returns>true: create success
        ///         false: create fail</returns>
        Task<bool> CreateFeedbackAsync(FeedbackCreateDTO feedback);
        /// <summary>
        /// Service answer the question Feedback of User
        /// </summary>
        /// <param name="id">Id of Feedback</param>
        /// <param name="feedback">Feedback information update</param>
        /// <returns>me="screenShot">File screenShot</param>
        /// <returns>true: create success
        ///         false: create fail</returns>
        Task<bool> UpdateAnswerFeedbackAsync(int id,FeedbackAnswerDTO feedback);
        /// <summary>
        /// Service get all Feedback of user with paging
        /// </summary>
        /// <param name="request">PageSize: number record; PageCurrent: position page</param>
        /// <returns>List FeedbackDTO</returns>
        Task<PaginatedList<FeedbackDTO>> GetFeedbackAsyncPaging(PagingRequest request);
        /// <summary>
        /// Service get all Feedback of specify user with paging
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="request">PageSize: number record; PageCurrent: position page</param>
        /// <returns>List FeedbackDTO</returns>
        Task<PaginatedList<FeedbackDTO>> GetFeedbackUserByIdAsyncPaging(int id,PagingRequest request);
    }
}

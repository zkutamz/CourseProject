using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IFeedbackRepository :  IRepository<Feedback>
    {
        /// <summary>
        /// Get all feedback of user with paging
        /// </summary>
        /// <param name="pagingRequest">PageSize: number record; PageCurrent: position page</param>
        /// <returns>List Feedback</returns>
        Task<PaginatedList<Feedback>> GetAllFeedbackPaging(PagingRequest pagingRequest);
        /// <summary>
        /// Get all feedback of specify user with paging
        /// </summary>
        /// <param name="userId">Id of user</param>
        /// <param name="pagingRequest">PageSize: number record; PageCurrent: position page</param>
        /// <returns>List Feedback</returns>
        Task<PaginatedList<Feedback>> GetAllFeedbackUserByIdPaging(int userId,PagingRequest pagingRequest);
        /// <summary>
        /// Get Feedback by Id
        /// </summary>
        /// <param name="id">Ido feedback</param>
        /// <returns>Feedback</returns>
        Task<Feedback> GetFeedbackById(int id);
    }
}

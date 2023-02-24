using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IFAQRepository : IRepository<FAQ>
    {
        /// <summary>
        /// Get FAQ with paging
        /// </summary>
        /// <param name="pagingRequest">pageNumber: position of page, pageSize: number record</param>
        /// <returns>List FAQDTO</returns>
        Task<PaginatedList<FAQ>> GetFAQPaging(PagingRequest pagingRequest);
        /// <summary>
        /// Get all FAQ
        /// </summary>
        /// <returns>List FAQ</returns>
        Task<List<FAQ>> GetAllFAQAsync();
        /// <summary>
        /// Get FAQ detail
        /// </summary>
        /// <param name="id">Id of FAQ</param>
        /// <returns>FAQ detail</returns>
        Task<FAQ> GetFAQById(int? id);
    }
}

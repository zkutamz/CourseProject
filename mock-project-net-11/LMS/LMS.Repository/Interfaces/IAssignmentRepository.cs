using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        /// <summary>
        /// Get Assignment Detail
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        Task<Assignment> GetAssignmentDetailAsync(int id);
    }
}

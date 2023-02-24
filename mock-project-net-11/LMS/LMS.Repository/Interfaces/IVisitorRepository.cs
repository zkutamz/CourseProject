using LMS.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IVisitorRepository : IRepository<Visitor>
    {
        /// <summary>
        /// Get total view of instructor by day 
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<int> GetTotalViewOfInstructorByDay(int instructorId, string date);
        /// <summary>
        /// Get list view of instructor weekly. from date now to past
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<Dictionary<int,int>> GetTotalViewOfInstructorWeekly(int instructorId, string date);
    }
}

using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        /// <summary>
        /// Get Quiz Detail
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        Task<Quiz> GetQuizDetailAsync(int assignmentId);
    }
}

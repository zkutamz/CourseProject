using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IQuizQuestionRepository : IRepository<QuizQuestion>
    {
        /// <summary>
        /// Get Quiz Question Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<QuizQuestion> GetQuizQuestionDetailAsync(int id);
    }
}

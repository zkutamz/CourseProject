using LMS.Repository.Entities;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    /// <summary>
    /// Repo for QuizSection
    /// </summary>
    public interface IQuizSectionRepository : IRepository<QuizSection>
    {
        /// <summary>
        /// Get SectionId
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        Task<int> GetSectionId(int quizId);
    }
}

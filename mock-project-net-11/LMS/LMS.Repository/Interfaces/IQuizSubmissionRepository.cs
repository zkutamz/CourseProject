using LMS.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IQuizSubmissionRepository : IRepository<QuizSubmission>
    {
        /// <summary>
        /// Get All Quiz Submission of user with QuizID
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="quizID">quizID</param>
        /// <returns>List<QuizSubmission></returns>
        Task<List<QuizSubmission>> GetAllQuizSubmission(int userID, int quizID);

        /// <summary>
        /// Get QuizSubmission By ID
        /// </summary>
        /// <param name="quizSubmissionID">quizSubmissionID</param>
        /// <returns>QuizSubmission</returns>
        Task<QuizSubmission> GetQuizSubmissionByID(int quizSubmissionID);
    }
}

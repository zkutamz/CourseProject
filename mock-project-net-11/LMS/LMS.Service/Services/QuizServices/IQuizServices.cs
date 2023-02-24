using LMS.Model.Request.QuizDTOs;
using LMS.Model.Response.QuizDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.QuizServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQuizServices
    {
        /// <summary>
        /// Create Quiz For Section
        /// </summary>
        /// <param name="quizCreateDTO"></param>
        /// <returns></returns>
        Task<QuizDTO> CreateQuizSectionAsync(QuizCreateDTO quizCreateDTO);
        /// <summary>
        /// Update information of a quiz
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<QuizDTO> UpdateQuizAsync(int quizId, QuizEditDTO request);

        /// <summary>
        /// Delete a Quiz
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        Task<bool> DeleteQuizAsync(int quizId);
        /// <summary>
        /// Get details information of a quiz
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        Task<QuizForSectionDTO> GetQuizDetailsAsync(int quizId);
    }
}

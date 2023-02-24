using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.QuizSubmissionServices
{
    public interface IQuizSubmissionServices
    {
        /// <summary>
        /// Create QuizSubmission after user completed the Quiz.
        /// </summary>
        /// <param name="quizSubmissionCreateDTO">QuizSubmissionCreateDTO</param>
        /// <returns>true: success, false: failed</returns>
        Task<int> CreateQuizSubmission(QuizSubmissionCreateDTO quizSubmissionCreateDTO);
       
        /// <summary>
        /// Check QuizSubmission to confirm user completed the quiz of Section.
        /// </summary>
        /// <param name="checkStatusStudyDTO">CheckStatusStudyDTO</param>
        /// <returns>true:completed, false:inprogress</returns>
        Task<bool> CheckQuizSubmissionCompleted(CheckStatusStudyDTO checkStatusStudyDTO);
        
        /// <summary>
        /// Get Quiz Submission By ID
        /// </summary>
        /// <param name="quizSubmissionID">quizSubmissionID</param>
        /// <returns>QuizSubmissionDTO</returns>
        Task<QuizSubmissionDTO> GetQuizSubmissionByID(int quizSubmissionID);
        
        /// <summary>
        /// Handle Quiz Result after user finished quiz, create quizsubmission and answer to save result of user.
        /// </summary>
        /// <param name="request">UserAnswersDTO</param>
        /// <returns>QuizSubmissionDTO</returns>
        Task<QuizSubmissionDTO> HandleQuizResult(UserAnswersDTO userAnswerDTO);

        /// <summary>
        /// Get All Quiz Submissions
        /// </summary>
        /// <param name="userAnswerDTO">UserAnswersDTO</param>
        /// <returns>List<QuizSubmissionDTO></returns>
        Task<List<QuizSubmissionDTO>> GetAllQuizSubmissions(int userID, int quizID);
    }
}

using LMS.Model.Request.QuizQuestionDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.QuizQuestionServices
{
    public interface IQuizQuestionServices
    {
        /// <summary>
        /// Create a quiz question
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<QuizQuestionResponseDTO> CreateQuizQuestionAsync(QuizQuestionCreateDTO request);
        /// <summary>
        /// Create multiple questions
        /// </summary>
        /// <param name="quizQuestionsCreateDTO"></param>
        /// <returns></returns>
        Task<List<QuizQuestionResponseDTO>> CreateQuizQuestionsAsync(List<QuizQuestionCreateDTO> quizQuestionsCreateDTO);
        /// <summary>
        /// Update Quiz Question
        /// </summary>
        /// <param name="quizQuestionId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> UpdateQuizQuestionAsync(int quizQuestionId, QuizQuestionEditDTO request);
        /// <summary>
        /// Soft delete a quiz question
        /// </summary>
        /// <param name="quizQuestionId"></param>
        /// <returns></returns>
        Task<bool> DeleteQuizQuestionAsync(int quizQuestionId);
        /// <summary>
        /// Get Quiz details
        /// </summary>
        /// <param name="quizQuestionId"></param>
        /// <returns></returns>
        Task<QuizQuestionDetailDTO> GetQuizQuestionDetailAsync(int quizQuestionId);

        /// <summary>
        /// Create Quiz Question FromFile
        /// </summary>
        /// <param name="fileExcel">fileExcel</param>
        /// <param name="quizID">quizID</param>
        /// <returns>List<QuizQuestionResponseDTO></returns>
        Task<List<QuizQuestionResponseDTO>> CreateQuizQuestionFromFile(string fileName, int quizID);
    }
}

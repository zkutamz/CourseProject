using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.LessonCompletionDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.LessonCompletionServices
{
    public interface ILessonCompletionServices
    {
        /// <summary>
        /// Create Lesson completion after user completed the lesson
        /// </summary>
        /// <param name="lessonCompletionCreateDTO">lessonCompletionCreateDTO</param>
        /// <returns>true:success false: failed</returns>
        Task<bool> CreateLessonCompletion(LessonCompletionCreateDTO lessonCompletionCreateDTO);
        
        /// <summary>
        /// Check lesson completion to confirm user completed the lesson of Section
        /// </summary>
        /// <param name="checkStatusStudyDTO">checkStatusStudyDTO</param>
        /// <returns>true: completed< false: inprogress</returns>
        Task<bool> CheckLessonCompleted(CheckStatusStudyDTO checkStatusStudyDTO);
    }
}

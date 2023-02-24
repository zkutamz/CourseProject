using LMS.Model.Request.AssignmentSubmissionsDTOs;
using LMS.Model.Request.CommonDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.AssignmentSubmissionServices
{
    public interface IAssignmentSubmissionServices
    {
        /// <summary>
        /// After completed the assignment, Create assignment submission to save result
        /// </summary>
        /// <param name="assignmentSubmissionsCreateDTO"></param>
        /// <returns>true:success, false: failed</returns>
        Task<bool> CreateAssignmentSubmission(AssignmentSubmissionsCreateDTO assignmentSubmissionsCreateDTO);
        
        /// <summary>
        /// Check Assignment Submission to confirm user completed the assignment of Section
        /// </summary>
        /// <param name="checkStatusStudyDTO">CheckStatusStudyDTO</param>
        /// <returns>true: completed, false: inprogress</returns>
        Task<bool> CheckAssignmentSubmissionCompleted(CheckStatusStudyDTO checkStatusStudyDTO);
    }
}

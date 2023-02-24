using LMS.Model.Request.AssignmentDTOs;
using LMS.Model.Response.AssignmentDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.AssignmentServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssignmentServices
    {
        /// <summary>
        /// Create Assignment
        /// </summary>
        /// <param name="assignmentCreateDTO"></param>
        /// <returns></returns>
        Task<AssignmentDTO> CreateAssignmentAsync(AssignmentCreateDTO assignmentCreateDTO);

        /// <summary>
        /// Update Assignment
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> UpdateAssignmentAsync(int assignmentId, AssignmentEditDTO request);

        /// <summary>
        /// Delete Assignment
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        Task<bool> DeleteAssignmentAsync(int assignmentId);

        /// <summary>
        /// This method gets an assignment detail.
        /// </summary>
        /// <param name="assignmentId">Assignment ID to filter</param>
        /// <returns>An assignment detail DTO object</returns>
        Task<AssignmentDetailDTO> GetAssignmentDetailAsync(int assignmentId);
    }
}

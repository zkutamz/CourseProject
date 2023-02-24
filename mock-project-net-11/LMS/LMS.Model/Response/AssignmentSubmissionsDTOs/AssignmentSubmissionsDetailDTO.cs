using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.AssignmentDTOs;
using LMS.Model.Response.SectionDTOs;

namespace LMS.Model.Response.AssignmentSubmissionsDTOs
{
    public class AssignmentSubmissionsDetailDTO : AssignmentSubmissionsDTO
    {
        public string FileUrl { get; set; }
        public AppUserDTO User { get; set; }
        public AssignmentDTO Assignment { get; set; }
        public SectionDTO Section { get; set; }
    }
}

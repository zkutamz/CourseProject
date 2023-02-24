using LMS.Model.Response.AttachmentDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.AssignmentDTOs
{
    public class AssignmentDetailDTO : AssignmentDTO
    {
        public int TotalNumber { get; set; }
        public int MinimumPassNumber { get; set; }
        public List<AttachmentDTO> Attachments { get; set; }
    }
}

using LMS.Model.Response.AttachmentDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.AssignmentDTOs
{
    public class AssignmentBasicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTime { get; set; }
        public bool IsComplete { get; set; }
        public List<AttachmentDTO> Attachments { get; set; }
    }
}
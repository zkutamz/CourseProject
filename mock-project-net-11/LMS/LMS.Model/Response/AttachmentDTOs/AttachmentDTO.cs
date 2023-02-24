using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.AttachmentDTOs
{
    public class AttachmentDTO
    {
        public int Id { get; set; }
        public string AttachmentUrl { get; set; }
        public long Size { get; set; }
        public int? LessonId { get; set; }
        public int? AssignmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

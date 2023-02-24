using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Request.AttachmentDTOs
{
    public class AttachmentCreateDTO
    {
        public string AttachmentUrl { get; set; }
        public long Size { get; set; }
        public int? LessonId { get; set; }
        public int? AssignmentId { get; set; } = null;
        public bool IsDelete { get; set; } = false;
    }
}

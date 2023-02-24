using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.AssignmentSubmissionsDTOs
{
    public class AssignmentSubmissionsEditDTO
    {
        [Required]
        public string FileUrl { get; set; }
        [Required]
        public string Answer { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

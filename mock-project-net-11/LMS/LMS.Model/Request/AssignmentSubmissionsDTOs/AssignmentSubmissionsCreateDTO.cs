using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;


namespace LMS.Model.Request.AssignmentSubmissionsDTOs
{
    /// <summary>
    /// AssignmentSubmissionsCreateDTO is used in AssignmentSubmissionsController, AssignmentSubmissionServices 
    /// to create AssignmentSubmissions.
    /// </summary>
    public class AssignmentSubmissionsCreateDTO
    {
        public string FileName { get; set; }
        [Required(ErrorMessage = "Answer is required")]
        public string Answer { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? AssignmentId { get; set; }
    }
}

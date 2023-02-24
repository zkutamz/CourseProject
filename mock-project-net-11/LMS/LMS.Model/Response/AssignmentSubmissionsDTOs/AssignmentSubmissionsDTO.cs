using System;

namespace LMS.Model.Response.AssignmentSubmissionsDTOs
{
    /// <summary>
    /// Use in AssignmentSubmissions service to get information AssignmentSubmissions.
    /// </summary>
    public class AssignmentSubmissionsDTO
    {
        public int Id { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Answer { get; set; }
        public float PercentCompleted { get; set; }
    }
}

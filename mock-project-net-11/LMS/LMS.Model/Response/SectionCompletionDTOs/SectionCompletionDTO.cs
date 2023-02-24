using System;

namespace LMS.Model.Response.SectionCompletionDTOs
{
    public class SectionCompletionDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime CompleteDate { get; set; }
       public int UserId { get; set; }
       public int SectionId { get; set; }
    }
}
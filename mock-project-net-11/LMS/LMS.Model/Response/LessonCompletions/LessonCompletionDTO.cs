using System;

namespace LMS.Model.Response.LessonCompletions
{
    public class LessonCompletionDTO
    {
        public int Id { get; set; }
        public DateTime CompletedDate { get; set; }
        public int LessonId { get; set; }
        public int SectionId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}

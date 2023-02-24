using System;

namespace LMS.Model.Request.LessonCompletionDTOs
{
    /// <summary>
    /// LessonCompletionCreateDTO is used in LessonCompletionsController, LessonCompletionServices 
    /// to create LessonCompletion.
    /// </summary>
    public class LessonCompletionCreateDTO
    {
        public int LessonId { get; set; }
        public int UserId { get; set; }
    }
}

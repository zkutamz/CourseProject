
using System;
using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.Lessons;

namespace LMS.Model.Request.NotesDTOs
{
    public class NotesCreateDTO
    {
        public string Content { get; set; }
        public int EnrollCourseId { get; set; }
        public int LessonId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.Lessons;

namespace LMS.Model.Response.NotesDTOs
{
    public class NotesDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public LessonDTO Lesson { get; set; }
        public EnrollCourseDTO EnrollCourse { get; set; }
    }
}

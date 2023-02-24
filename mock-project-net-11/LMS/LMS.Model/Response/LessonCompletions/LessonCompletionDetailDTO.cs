using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.Lessons;
using LMS.Model.Response.SectionDTOs;

namespace LMS.Model.Response.LessonCompletions
{
    public class LessonCompletionDetailDTO : LessonCompletionDTO
    {
        public LessonDTO Lesson { get; set; }
        public SectionDTO Section { get; set; }
        public AppUserDTO User { get; set; }
    }
}

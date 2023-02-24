using LMS.Model.Response.LessonCompletions;
using LMS.Model.Response.NotesDTOs;
using LMS.Model.Response.SectionDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.Lessons
{
    public class LessonDetailDTO : LessonCompletionDTO
    {
        public List<NotesDTO> NotesDTO { get; set; }
        public List<LessonCompletionDTO> LessonCompletionsDTO { get; set; }
        public SectionDTO SectionDTO { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.NotesDTOs
{
    public class NoteDetailModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
    }
}

using LMS.Model.Response.AssignmentDTOs;
using LMS.Model.Response.Lessons;
using LMS.Model.Response.QuizSectionDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.SectionDTOs
{
    /// <summary>
    /// This dto is for getting basic section information and it related content like LessonDTOs, AssignmentDTOs, and QuizDTOs
    /// Used in:
    ///     + SectionService:
    ///         - GetSectionBasicDTOsForCourseContentAsync
    /// </summary>
    public class SectionBasicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalTime { get; set; }
        public int Position { get; set; }
        public int TotalItems { get => Lessons.Count + Assignments.Count + QuizSections.Count; }
        //public int QuizTotalTime { get; }

        public List<LessonBasicDTO> Lessons { get; set; }
        public List<AssignmentBasicDTO> Assignments { get; set; }
        //public List<QuizBasicDTO> Quizzes { get; set; }
        public List<QuizSectionDTO> QuizSections { get; set; }
    }
}

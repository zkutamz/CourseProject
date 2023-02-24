using System.Collections.Generic;
using LMS.Model.Response.AnswerDTOs;

namespace LMS.Model.Response.QuizDTOs
{
    /// <summary>
    /// This dto is use for storing basic quiz information and it completion status.
    /// Used in:
    ///     + SectionService:
    ///         - GetSectionBasicDTOsForCourseContentAsync
    /// </summary>
    public class QuizBasicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTime { get; set; }
        public bool IsComplete { get; set; }
        //public List<AnswerBasicDTO> AnswerBasicDTOs { get; set; }
    }
}
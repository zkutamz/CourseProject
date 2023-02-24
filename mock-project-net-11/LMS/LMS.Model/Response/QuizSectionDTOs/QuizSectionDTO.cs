using LMS.Model.Response.QuizDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.QuizSectionDTOs
{
    /// <summary>
    /// This dto is for storing basic quiz information and it completion status.
    /// Used in:
    ///     + SectionService:
    ///         - GetSectionBasicDTOsForCourseContentAsync.
    /// </summary>
    public class QuizSectionDTO
    {
        public QuizBasicDTO Quiz { get; set; }
    }
}

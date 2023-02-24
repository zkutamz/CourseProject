using System.Collections.Generic;
using LMS.Model.Response.AssignmentDTOs;
using LMS.Model.Response.AssignmentSubmissionsDTOs;
using LMS.Model.Response.LessonCompletions;
using LMS.Model.Response.Lessons;
using LMS.Model.Response.QuizDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Model.Response.SectionCompletionDTOs;

namespace LMS.Model.Response.SectionDTOs
{
    public class SectionDetailDTO : SectionDTO
    {
        #region Navigational properties

        public List<LessonDTO> Lessons { get; set; }
        public List<AssignmentDTO> Assignments { get; set; }
        public List<QuizDTO> Quizzes { get; set; }
        public List<QuizSubmissionDTO> QuizSubmissions { get; set; }
        public List<LessonCompletionDTO> LessonCompletions { get; set; }
        public List<SectionCompletionDTO> SectionCompletions { get; set; }
        public List<AssignmentSubmissionsDTO> AssignmentSubmissions { get; set; }

        #endregion
    }
}
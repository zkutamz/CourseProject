using LMS.Model.Response.AnswerDTOs;
using System;
using System.Collections.Generic;

namespace LMS.Model.Response.QuizSubmissionDTOs
{
    /// <summary>
    /// Use in Quizsubmision service to get result the quiz of user.
    /// </summary>
    public class QuizSubmissionDTO
    {
        #region Properties
        public int Id { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CorectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int TotalQuestion { get; set; }
        public bool IsPassed { get; set; }
#nullable enable
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
#nullable disable
        #endregion
        public List<AnswerDTO> Answers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.QuizQuestionDTOs
{
    /// <summary>
    /// Use in Quizsubmision service to get result the quiz of user after user done quiz.
    /// </summary>
    public class QuizQuestionHandleResultQuizDTO
    {      
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public string ExplanationImageURL { get; set; }
    }
}

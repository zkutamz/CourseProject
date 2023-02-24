using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.QuizQuestionDTOs
{
    /// <summary>
    /// Use in Quizsubmision service Caculate quiz of user after user done quiz.
    /// </summary>
    public class QuizQuestionMarkDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string AudioURL { get; set; }
        public string VideoURL { get; set; }
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public string ExplanationImageURL { get; set; }
    }
}

using System.Collections.Generic;
using LMS.Model.Request.QuizQuestionDTOs;
using LMS.Model.Response.AnswerDTOs;
using LMS.Model.Response.QuizDTOs;

namespace LMS.Model.Response.QuizQuestionDTOs
{
    /// <summary>
    /// Quiz question details
    /// </summary>
    public class QuizQuestionDetailDTO : QuizQuestionEditDTO
    {
        #region Relationship
        public QuizDTO Quiz { get; set; }
        #endregion
    }
}
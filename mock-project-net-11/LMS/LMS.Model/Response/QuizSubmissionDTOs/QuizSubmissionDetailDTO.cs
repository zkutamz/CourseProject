using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.QuizDTOs;
using LMS.Model.Response.SectionDTOs;
using System.Collections.Generic;
using LMS.Model.Response.AnswerDTOs;

namespace LMS.Model.Response.QuizSubmissionDTOs
{
    public class QuizSubmissionDetailDTO : QuizSubmissionDTO
    {
        #region RelationshipConfiguration
        public QuizDTO Quiz { get; set; }
        public AppUserDTO User { get; set; }
        public SectionDTO Section { get; set; }

        #endregion
    }
}
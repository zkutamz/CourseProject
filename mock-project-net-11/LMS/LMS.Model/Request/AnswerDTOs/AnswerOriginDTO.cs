using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Request.AnswerDTOs
{
    public class AnswerOriginCreateDTO
    {
        public string Content { get; set; }
        public int QuizQuestionId { get; set; }
    }
}

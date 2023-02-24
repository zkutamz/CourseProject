using LMS.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Request.FeedbackDTOs
{
    public class FeedbackAnswerDTO
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public FeedbackStatus Status { get; set; }

    }
}

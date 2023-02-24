using LMS.Model.Response.FeedbackDTOs;
using System;

namespace LMS.Model.Request.FeedbackDTOs
{
    public class FeedbackEditDTO : FeedbackDTO
    {
        public string Answer { get; set; }
    }
}

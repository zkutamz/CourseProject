using LMS.Model.Response.CourseDTOs;
using System;

namespace LMS.Model.Response.FAQs
{
    public class FAQDetailDTO : FAQDTO
    {
        public string Answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

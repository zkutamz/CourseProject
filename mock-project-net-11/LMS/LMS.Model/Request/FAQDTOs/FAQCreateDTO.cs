using System;

namespace LMS.Model.Request.FAQDTOs
{
    public class FAQCreateDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int HelpId { get; set; }
    }
}

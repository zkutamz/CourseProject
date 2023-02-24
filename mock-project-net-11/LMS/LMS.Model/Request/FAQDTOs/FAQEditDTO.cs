using LMS.Model.Request.FAQDTOs;
using System;

namespace LMS.Model.Request.FAQDTOs
{
    public class FAQEditDTO : FAQCreateDTO
    {
        public int Id { get; set; }
        public DateTime  UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}

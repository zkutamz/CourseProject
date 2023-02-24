using System;

namespace LMS.Model.Request.CourseDiscountDTOs
{
    public class CourseDiscountCreateDTO
    {
        public int CourseId { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

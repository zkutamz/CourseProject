using System;

namespace LMS.Model.Request.CoursePromotionDTOs
{
    public class CoursePromotionCreateDTO
    {
        public string Tittle { get; set; }
        public string CouponCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive => DateTime.Now > StartDate && DateTime.Now < EndDate;

    }
}

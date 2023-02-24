using LMS.Model.Response.OrderHeaderDTOs;
using System;
using System.Collections.Generic;

namespace LMS.Model.Response.CoursePromotionDTOs
{
    public class CoursePromotionDTO
    {
        public string Tittle { get; set; }
        public string CouponCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public ICollection<OrderHeaderDTO> OrderHeaders { get; set; }
    }
}

using LMS.Model.Response.CourseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.ShoppingCartDTOs
{
    public class ShoppingCartDto
    {
        public List<CourseDTO> courseDTOs { get; set; } = new List<CourseDTO>();
        public decimal OriginalPrice { get; set; } = 0;
        public decimal DiscountPrice { get; set; } = 0;
        public string CouponCode { get; set; } = null;
        public decimal TotalPrice => OriginalPrice  - DiscountPrice;
    }
}

using System;

namespace LMS.Model.Request.OrderDetailDTOs
{
    public class OrderDetailCreateDTO
    {
        public decimal Price { get; set; }
        public int CourseId { get; set; }
        public int OrderHeaderId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

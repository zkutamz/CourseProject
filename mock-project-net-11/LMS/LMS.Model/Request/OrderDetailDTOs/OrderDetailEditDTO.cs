using System;

namespace LMS.Model.Request.OrderDetailDTOs
{
    public class OrderDetailEditDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int CourseId { get; set; }
        public int OrderHeaderId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}

using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.OrderHeaderDTOs;
using System;


namespace LMS.Model.Response.OrderDetailDTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public Decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CourseId { get; set; }
        public OrderHeaderDTO OrderHeader { get; set; }
        public int OrderHeaderId { get; set; }
        public CourseDTO Course { set; get; }
    }
}

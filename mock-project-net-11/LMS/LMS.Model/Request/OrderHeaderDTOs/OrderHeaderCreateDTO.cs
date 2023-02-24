using LMS.Model.Request.OrderDetailDTOs;
using LMS.Repository.Enums;
using System;
using System.Collections.Generic;

namespace LMS.Model.Request.OrderHeaderDTOs
{
    public class OrderHeaderCreateDTO
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderTotal { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int SessionId { get; set; }
        public int PaymentMethodId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<OrderDetailCreateDTO> OrderDetails { get; set; }
    }
}

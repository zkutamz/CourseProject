using LMS.Repository.Enums;
using System;


namespace LMS.Model.Response.OrderHeaderDTOs
{
    public class OrderHeaderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int SessionId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}

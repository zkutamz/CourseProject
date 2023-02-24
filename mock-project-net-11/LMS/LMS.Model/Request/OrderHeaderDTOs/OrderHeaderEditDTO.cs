using LMS.Model.Response.OrderHeaderDTOs;
using System;


namespace LMS.Model.Request.OrderHeaderDTOs
{
   public class OrderHeaderEditDTO : OrderHeaderDTO
    {
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}

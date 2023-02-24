using LMS.Model.Response.OrderDetailDTOs;
using System.Collections.Generic;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.PaymentMethodDTOs;

namespace LMS.Model.Response.OrderHeaderDTOs
{
    public class OrderHeaderDetailDTO : OrderHeaderDTO
    {
        public AppUserDTO User { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
        public PaymentMethodDTO PaymentMethods { get; set; }
    }
}

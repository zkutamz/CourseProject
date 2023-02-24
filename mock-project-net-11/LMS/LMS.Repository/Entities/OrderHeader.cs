using System;
using System.Collections.Generic;
using LMS.Repository.Enums;

namespace LMS.Repository.Entities
{
    public class OrderHeader : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int SessionId { get; set; }
        public int PaymentMethodId { get; set; }
        public int? CouponCode { get; set; }

        #region Navigational Properties
        /// <summary>
        /// relationship 1:N User
        /// </summary>
        public AppUser User { get; set; }
        /// <summary>
        /// relationship N:1 OrderDetails
        /// </summary>
        public List<OrderDetail> OrderDetails  { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PaymentMethod PaymentMethods { get; set; }
        public CoursePromotion CoursePromotion { get; set; }
        #endregion
    }
}
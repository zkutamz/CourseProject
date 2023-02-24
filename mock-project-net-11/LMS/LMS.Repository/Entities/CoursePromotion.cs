using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class CoursePromotion : BaseEntity
    {
        public string Tittle { get; set; }
        public int VendorId { get; set; }
        public string CouponCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive => DateTime.Now > StartDate && DateTime.Now < EndDate;
        public ICollection<OrderHeader> OrderHeaders { get; set; }
        public AppUser Vendor { get; set; }

    }
}

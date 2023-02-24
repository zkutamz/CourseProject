using System;

namespace LMS.Repository.Entities
{
    public partial class CourseDiscount : BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

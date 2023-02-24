using System;

namespace LMS.Repository.Entities
{
    public class ShoppingCart
    {
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime Created { get; set; }
        public bool IsPending { get; set; } = true;
        public bool IsDelete { get; set; }
    }
}

using System;

namespace LMS.Repository.Entities
{
    public class UserSubcriber
    {
        public int UserId { get; set; }
        public int SubcriberId { get; set; }
        public AppUser User { get; set; }
        public AppUser Subscriber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

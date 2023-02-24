namespace LMS.Repository.Entities
{ public class Specializations :BaseEntity

    {
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

    }
}

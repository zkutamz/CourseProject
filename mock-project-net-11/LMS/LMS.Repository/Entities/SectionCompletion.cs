using System;

namespace LMS.Repository.Entities
{
   public class SectionCompletion

    {
       public DateTime CompleteDate { get; set; }
       public int UserId { get; set; }
       public virtual AppUser User { get; set; }
       public int SectionId { get; set; }
       public virtual Section Section { get; set; }

    }
}

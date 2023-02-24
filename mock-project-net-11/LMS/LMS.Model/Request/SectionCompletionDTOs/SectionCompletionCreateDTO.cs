using System;

namespace LMS.Model.Request.SectionCompletionDTOs
{
    public class SectionCompletionCreateDTO
    {
        public DateTime CompleteDate { get; set; }
       public int UserId { get; set; }
       public int SectionId { get; set; }

    }
}
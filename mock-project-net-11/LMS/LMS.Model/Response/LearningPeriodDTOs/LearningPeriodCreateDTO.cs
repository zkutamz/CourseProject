using System;

namespace LMS.Model.Response.LearningPeriodDTOs
{
    public class LearningPeriodCreateDTO
    {
        public DateTime LearningDate { get; set; }
        public float Period { get; set; }
        public int UserId { get; set; }
    }
}

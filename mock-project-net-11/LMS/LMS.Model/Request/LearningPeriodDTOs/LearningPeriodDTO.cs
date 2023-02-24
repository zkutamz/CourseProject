using System;

namespace LMS.Model.Request.LearningPeriodDTOs
{
    public class LearningPeriodDTO
    {
        public int Id { get; set; }
        public DateTime LearningDate { get; set; }
        public float Period { get; set; }
    }
}

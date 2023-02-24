using System;
using LMS.Model.Response.AppUserDTOs;

namespace LMS.Model.Request.LearningPeriodDTOs
{
    public class LearningPeriodDetailDTO
    {
        public int Id { get; set; }
        public DateTime LearningDate { get; set; }
        public float Period { get; set; }
        public AppUserDTO User { get; set; }
    }
}

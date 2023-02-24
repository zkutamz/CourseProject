using System;

namespace LMS.Model.Request.EnrollCourseDTOs
{
    public class EnrollCourseCreateDTO
    {
        public decimal CompletedPercent { get; set; }
        public string CertificationURL { get; set; }
        public DateTime CertificationDate { get; set; }
        public string Note { get; set; }
        public int Score { get; set; }
        public bool IsCertificate { get; set; }
        public DateTime EnrollDate { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}

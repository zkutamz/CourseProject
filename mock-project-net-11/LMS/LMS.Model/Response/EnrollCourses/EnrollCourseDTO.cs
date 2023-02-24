using System;

namespace LMS.Model.Response.EnrollCourses
{
    public class EnrollCourseDTO : EnrollCourseBasicDTO
    {
        public decimal CompletedPercent { get; set; }
        public string CertificationURL { get; set; }
        public DateTime CertificationDate { get; set; }
        public string Note { get; set; }
        public int Score { get; set; }
        public bool IsCertificate { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsDelete { get; set; }
    }
}

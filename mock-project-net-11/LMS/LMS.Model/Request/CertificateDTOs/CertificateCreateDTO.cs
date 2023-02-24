using System;

namespace LMS.Model.Request
{
    public class CertificateCreateDTO
    {
        public string CertificateName { get; set; }
        public int? CertificateCategoryId { get; set; } = null;
        public bool IsForCourse { get; set; }
        public int CourseId { get; set; }
    }

}

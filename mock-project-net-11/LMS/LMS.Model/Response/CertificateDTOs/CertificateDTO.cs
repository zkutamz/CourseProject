using System;

namespace LMS.Model.Response.CertificateDTOs
{
    public class CertificateDTO
    {
        public int Id { get; set; }
        public string CertificateName { get; set; }
        public int? CertificateCategoryId { get; set; }
        public int? CourseId { get; set; }
        public bool IsForCourse { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}

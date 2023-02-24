using System;

namespace LMS.Model.Request.QuizCertificateDTOs
{
    public class QuizCerificateCreateDTO
    {
        public int CertificateId { get; set; }
        public int QuizzId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

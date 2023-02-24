using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.QuizCertificateDTOs
{
    public class QuizCertificateDTO
    {
        public int CertificateId { get; set; }
        public int QuizzId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}

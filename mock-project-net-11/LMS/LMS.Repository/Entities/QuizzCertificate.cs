using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class QuizzCertificate
    {
        public int CertificateId { get; set; }
        public int QuizzId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
        public Certificate Certificate { get; set; }
        public Quiz Quiz { get; set; }
    }
}

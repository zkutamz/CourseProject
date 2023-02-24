using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class UserCertificate
    {
        public int UserId { get; set; }
        public int CertificateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
        public string ImageCertificateUrl { get; set; }
        public Certificate Certificate { get; set; }
        public AppUser User { get; set; }
    }
}

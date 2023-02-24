using System;

namespace LMS.Model.Request.UserCertificateDTOs
{
    public class UserCertificateDTO
    {
        public int UserId { get; set; }
        public int CertificateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

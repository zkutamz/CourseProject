using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CertificateDTOs;
using System;

namespace LMS.Model.Response.UserCertigicateDTOs
{
    public class UserCertificateDetailDTO
    {
        public int UserId { get; set; }
        public int CertificateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
        public string ImageCertificateUrl { get; set; }
        public CertificateDTO Certificate { get; set; }
        public AppUserDTO User { get; set; }
    }
}

using LMS.Model.Response.CertificateDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CertificateCategoryDTOs
{
    public class CertificateCategoryDetailDTO: CertificateCategoryDTO
    {
        public CertificateDTO CertificateDTO { get; set; }
    }
}

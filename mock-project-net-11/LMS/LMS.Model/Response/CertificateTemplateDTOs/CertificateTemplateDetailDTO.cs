using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.TemplateDTOs;

namespace LMS.Model.Response.CertificateTemplateDTOs
{
    public class CertificateTemplateDetailDTO : CertificateTemplateDTO
    {
        public CertificateDTO Certificate { get; set; }
        public TemplateDTO Template { get; set; }
    }
}
using LMS.Model.Response.CertificateTemplateDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.TemplateDTOs
{
    public class TemplateDetailDTO : TemplateDTO
    {
        public List<CertificateTemplateDTO> CertificateTemplates { get; set; }
    }
}

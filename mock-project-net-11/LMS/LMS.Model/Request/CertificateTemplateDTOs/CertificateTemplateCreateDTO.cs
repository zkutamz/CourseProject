using Microsoft.AspNetCore.Http;

namespace LMS.Model.Request.CertificateTemplateDTOs
{
    public class CertificateTemplateCreateDTO
    {
        public string TemplateName { get; set; }
        public IFormFile TemplateData { get; set; }
    }
}

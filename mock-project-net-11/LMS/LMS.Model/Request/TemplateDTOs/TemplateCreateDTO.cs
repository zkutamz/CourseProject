using Microsoft.AspNetCore.Http;

namespace LMS.Model.Request.TemplateDTOs
{
    public class TemplateCreateDTO
    {
        public string TemplateName { get; set; }
        public bool IsTemplateForCourse { get; set; } = false;
        public IFormFile TemplateData { get; set; }
    }
}

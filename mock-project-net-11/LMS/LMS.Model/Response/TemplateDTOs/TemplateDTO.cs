using LMS.Repository.Entities;

namespace LMS.Model.Response.TemplateDTOs
{
    public class TemplateDTO
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateUrl { get; set; }
        public bool IsTemplateForCourse { get; set; }
    }
}

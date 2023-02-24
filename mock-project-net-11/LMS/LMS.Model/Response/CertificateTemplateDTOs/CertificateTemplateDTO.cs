using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CertificateTemplateDTOs
{
    public class CertificateTemplateDTO
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateUrl { get; set; }
        public bool IsTemplateForCourse { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

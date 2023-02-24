using LMS.Model.Request.UserCertificateDTOs;
using LMS.Model.Response.CertificateCategoryDTOs;
using LMS.Model.Response.CertificateTemplateDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.QuizCertificateDTOs;
using LMS.Model.Response.QuizDTOs;
using LMS.Model.Response.TemplateDTOs;
using LMS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LMS.Model.Response.CertificateDTOs
{
    public class CertificateDetailDTO : CertificateDTO
    {
        public CertificateCategoryDTO CertificateCategory { get; set; }
        public QuizCertificateDTO QuizCertificate { get; set; }
        public List<UserCertificateDTO> UserCertificates { get; set; }
        public List<CertificateTemplateDTO> CertificateTemplates { get; set; }
        public CourseDTO Course { get; set; }
    }
}

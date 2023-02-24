using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class store data of certificate
    /// </summary>
    public class Certificate: BaseEntity
    {
        #region Properties
        public string CertificateName { get; set; }
        public int? CertificateCategoryId { get; set; }
        public int? CourseId { get; set; }
        public bool IsForCourse { get; set; }
        #endregion

        #region Navigation
        public CertificateCategory CertificateCategory { get; set; }
        public QuizzCertificate QuizCertificate { get; set; }
        public List<UserCertificate> UserCertificates { get; set; }
        public List<CertificateTemplate> CertificateTemplates { get; set; }
        public Course Course { get; set; }
        #endregion
    }
}

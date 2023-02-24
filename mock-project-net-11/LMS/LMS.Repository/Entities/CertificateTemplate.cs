using System;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class is a result of many to many relationship between certificates and template tables
    /// </summary>
    public class CertificateTemplate
    {
        #region Properties
        public int CertificateId { get; set; }
        public int TemplateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
        #endregion
        #region Navigation
        public Certificate Certificate { get; set; }
        public Template Template { get; set; }
        #endregion
    }
}

using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class store data about template of certificate 
    /// </summary>
    public class Template : BaseEntity
    { 
        #region Properties
        /// <summary>
        /// Name of template
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// Ulr of template
        /// </summary>
        public string TemplateUrl { get; set; }
        /// <summary>
        /// True if template use for course certificate, otherwise false
        /// </summary>
        public bool IsTemplateForCourse { get; set; }
        #endregion
        #region Navigation
        public List<CertificateTemplate> CertificateTemplates { get; set; }
        #endregion
    }
}

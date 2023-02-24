using System;

namespace LMS.Model.Request.CertificateCategoryDTOs
{
    public class CertificateCategoryCreateDTO
    {
        public string CertificateCatgoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public bool IsDelete { get; set; } = false;
    }
}

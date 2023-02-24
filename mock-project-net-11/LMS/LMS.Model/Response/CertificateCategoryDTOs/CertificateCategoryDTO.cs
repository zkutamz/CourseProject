using System;

namespace LMS.Model.Response.CertificateCategoryDTOs
{
    public class CertificateCategoryDTO
    {
        public string Id { get; set; }
        public string CertificateCatgoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}

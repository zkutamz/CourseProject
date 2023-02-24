using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Entities
{
    public class CertificateCategory: BaseEntity
    {
        public string CertificateCatgoryName { get; set; }
        public List<Certificate> Certificate { get; set; }
    }
}

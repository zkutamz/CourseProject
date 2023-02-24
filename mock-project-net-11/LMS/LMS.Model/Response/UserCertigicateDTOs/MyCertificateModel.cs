using System;

namespace LMS.Model.Response.UserCertigicateDTOs
{
    public class MyCertificateModel
    {
        public int ItemNo { get; set; }
        public string Titile { get; set; }
        public int? Mark { get; set; }
        public int? OutOf { get; set; }
        public DateTime UpLoadDate{ get; set; }
        public string CertificateImageUrl { get; set; }
    }
}

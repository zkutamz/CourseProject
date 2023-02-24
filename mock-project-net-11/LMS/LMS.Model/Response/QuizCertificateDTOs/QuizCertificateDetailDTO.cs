using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.QuizDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.QuizCertificateDTOs
{
    public class QuizCertificateDetailDTO: QuizCertificateDTO
    {
        public CertificateDTO Certificate { get; set; }
        public QuizDTO Quiz { get; set; }
    }
}

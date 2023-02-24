using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Model.Response.UserCertigicateDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CertificateDTOs
{
    public class CertificateResultSubmitionDTO
    {
        public QuizSubmissionForCertificateResultDTO QuizSubmissionDTO { get; set; }
        public UserCertificateDetailDTO UserCertificateDetailDTO { get; set; }
    }
}

using LMS.Model.Response.CertificateDTOs;

namespace LMS.Model.Response.QuizSubmissionDTOs
{
    public class QuizzCertificateResultDTO
    {
        public AssignToCertificateResult AssignToCertificateResult { get; set; }
        public QuizSubmissionDTO QuizSubmission { get; set; }
    }
}

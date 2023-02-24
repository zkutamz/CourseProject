using LMS.Model.Response.QuizQuestionDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.QuizDTOs
{
    public class QuizDetailDTO : QuizDTO
    {
        public List<QuizQuestionResponseDTO> QuizQuestions { get; set; }
        //public SectionDTO Section { get; set; }
        //public List<QuizSubmissionDTO> QuizSubmissions { get; set; }
        /*public CategoryDTO Category { get; set; }
        public CertificateDTO Certificate { get; set; }*/
    }
}

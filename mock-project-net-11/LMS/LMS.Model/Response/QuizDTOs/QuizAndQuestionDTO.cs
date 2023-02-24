using LMS.Model.Response.CategoryDTOs;
using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Response.SectionDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.QuizDTOs
{
    /// <summary>
    /// junk
    /// </summary>
    public class QuizAndQuestionDTO : QuizDTO
    {
        public SectionDTO Section { get; set; }
        public List<QuizQuestionResponseDTO> QuizQuestions { get; set; }
        public CategoryDTO Category { get; set; }
        public CertificateDTO Certificate { get; set; }
    }
}

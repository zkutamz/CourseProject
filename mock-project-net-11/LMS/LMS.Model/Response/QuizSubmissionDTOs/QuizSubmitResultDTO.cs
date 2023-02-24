using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.QuizDTOs;
using LMS.Model.Response.SectionDTOs;

namespace LMS.Model.Response.QuizSubmissionDTOs
{
    public class QuizSubmitResultDTO : QuizSubmissionDTO
    {
        public QuizAndQuestionDTO QuizAndQuestion { get; set; }
        public AppUserDTO User { get; set; }
        public SectionDTO Section { get; set; }
    }
}

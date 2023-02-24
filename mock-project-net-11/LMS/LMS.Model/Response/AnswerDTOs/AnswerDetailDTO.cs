using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;

namespace LMS.Model.Response.AnswerDTOs
{
    public class AnswerDetailDTO : AnswerDTO
    {
        public QuizSubmissionDTO QuizSubmission { get; set; }
    }
}

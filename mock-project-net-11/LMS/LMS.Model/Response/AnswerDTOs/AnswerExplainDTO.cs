using LMS.Model.Response.QuizQuestionDTOs;

namespace LMS.Model.Response.AnswerDTOs
{
    public class AnswerExplainDTO
    {
        public string UserAnswer { get; set; }
        public QuizQuestionMarkDTO QuizQuestion { get; set; }
    }
}

using LMS.Model.Response.QuizQuestionDTOs;

namespace LMS.Model.Response.AnswerDTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public QuizQuestionHandleResultQuizDTO QuizQuestion { get; set; }
    }
}

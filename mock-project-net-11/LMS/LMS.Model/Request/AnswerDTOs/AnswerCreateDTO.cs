namespace LMS.Model.Request.AnswerDTOs
{
    public class AnswerCreateDTO
    {
        public string Content { get; set; }
        public int QuizQuestionId { get; set; }
        public int QuizSubmissionId { get; set; }
    }
}

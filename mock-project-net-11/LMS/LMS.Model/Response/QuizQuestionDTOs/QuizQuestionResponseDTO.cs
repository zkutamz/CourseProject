using LMS.Repository.Enums;

namespace LMS.Model.Response.QuizQuestionDTOs
{
    /// <summary>
    /// Use in Quizsubmision service show history do quiz of user.
    /// </summary>
    public class QuizQuestionResponseDTO
    {
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string AudioURL { get; set; }
        public string VideoURL { get; set; }
        public QuizQuestionType QuizQuestionType { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public string ExplanationImageURL { get; set; }
    }
}

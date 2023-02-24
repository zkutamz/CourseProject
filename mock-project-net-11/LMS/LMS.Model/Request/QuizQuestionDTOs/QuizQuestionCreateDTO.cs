using LMS.Repository.Enums;
using Microsoft.AspNetCore.Http;

namespace LMS.Model.Request.QuizQuestionDTOs
{
    public class QuizQuestionCreateDTO
    {
        #region Properties
        public string Title { get; set; }
#nullable enable
        public string? ImgURL { get; set; }
        public string? AudioURL { get; set; }
        public string? VideoURL { get; set; }
        public string? ExplanationImageURL { get; set; }
#nullable disable
        public QuizQuestionType QuizQuestionType { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public bool IsPublic { get; set; }
#nullable enable
        public int? QuizId { get; set; }
#nullable disable
        #endregion
    }
}
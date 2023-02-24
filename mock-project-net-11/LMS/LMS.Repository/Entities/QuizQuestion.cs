using LMS.Repository.Enums;
using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class QuizQuestion:BaseEntity
    {
        #region Properties
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
        public bool IsPublic { get; set; }
#nullable enable
        public int? QuizId { get; set; }
#nullable disable
        #endregion
        #region Relationship
        public Quiz Quiz { get; set; }
        public ICollection<Answer> Answers { get; set; }
        #endregion
    }
}

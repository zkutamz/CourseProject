using LMS.Repository.Enums;
using System;

namespace LMS.Model.Response.QuizQuestionDTOs
{
    /// <summary>
    /// Use in QuizQuestion service to get information of quiz question.
    /// </summary>
    public class QuizQuestionDTO
    {
        #region Properties
        public int Id { get; set; }
        public bool IsDelete { get; set; } = false;
        public QuizQuestionType QuizQuestionType { get; set; }
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string AudioURL { get; set; }
        public string VideoURL { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public bool IsPublic { get; set; }
#nullable enable
        public int? QuizId { get; set; }
        #endregion
    }
}
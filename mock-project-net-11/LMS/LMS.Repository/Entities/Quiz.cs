using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class Quiz : BaseEntity
    {
        #region Properties
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public int TotalTime { get; set; }
        public bool IsPublic { get; set; }
        public bool IsExposedQuestion { get; set; }

        #endregion

        #region Relationship
        public QuizSection QuizSection { get; set; }
        public ICollection<QuizSubmission> QuizSubmissions { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        public QuizzCertificate  QuizCertificate{ get; set; }
        #endregion
    }
}

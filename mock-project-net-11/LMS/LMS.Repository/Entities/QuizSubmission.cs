using System;
using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class QuizSubmission:BaseEntity
    {
        #region Properties
        public DateTime SubmitDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CorectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int TotalQuestion { get; set; }
        public bool IsPassed { get; set; }
#nullable enable
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
#nullable disable

        #endregion
        #region RelationshipConfiguration
        public Quiz Quiz { get; set; }
        public AppUser User { get; set; }
        public List<Answer> Answers { get; set; }
        #endregion
    }
}

namespace LMS.Repository.Entities
{
    /// <summary>
    ///  Entity Answers
    /// </summary>
    public class Answer : BaseEntity
    {
        #region Properties
        public string Content { get; set; }
        #endregion

        #region RelationProperties
        public int QuizQuestionId { get; set; }
        public int QuizSubmissionId { get; set; }
        public QuizQuestion QuizQuestion { get; set; }
        public QuizSubmission QuizSubmission { get; set; }
        #endregion
    }
}

namespace LMS.Model.Request.QuizSubmissionDTOs
{
    /// <summary>
    /// QuizSubmissionCreateDTO is used in QuizSubmissionServices, QuizSubmissionsController
    /// to create QuizSubmission.
    /// </summary>
    public class QuizSubmissionCreateDTO
    {
        #region Properties
        public int CorectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int TotalQuestion { get; set; }
        public bool IsPassed { get; set; }
#nullable enable
        public int? UserId { get; set; }
        public int? QuizId { get; set; }
#nullable disable
        #endregion
    }
}
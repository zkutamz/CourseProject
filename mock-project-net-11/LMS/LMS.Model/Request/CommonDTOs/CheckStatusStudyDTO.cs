namespace LMS.Model.Request.CommonDTOs
{
    /// <summary>
    /// CheckStatusStudyDTO is used AssignmentSubmissionsController, AssignmentSubmissionServices, 
    /// QuizSubmissionServices, QuizSubmissionsController,
    /// LessonCompletionsController, LessonCompletionServices 
    /// to check status studied of user.
    /// </summary>
    public class CheckStatusStudyDTO
    {
        public int UserID { get; set; }
        public int TypeCheckID { get; set; }
    }
}

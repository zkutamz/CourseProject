namespace LMS.Model.Response.AppUserDTOs
{
    /// <summary>
    /// This DTO has basic user's information and his/her total courses reviewed and enrolled.
    /// Use in:
    ///     + Featured review in course overview.
    /// </summary>
    public class AppUserReviewDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int NumberOfCoursesReviewed { get; set; }
        public int NumberOfCoursesEnrolled { get; set; }
    }
}

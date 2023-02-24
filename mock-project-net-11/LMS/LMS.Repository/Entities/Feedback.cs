using LMS.Repository.Enums;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// Feeback from user.
    /// </summary>
    public class Feedback : BaseEntity
    {
        #region Properties
        public string Email { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public FeedbackStatus Status { get; set; }
        public string ScreenShot { get; set; }
        #endregion

        #region Relationship Properties
        public int UserId { get; set; }
        public AppUser User { get; set; }
        #endregion
    }
}

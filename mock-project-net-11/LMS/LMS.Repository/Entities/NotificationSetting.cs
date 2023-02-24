namespace LMS.Repository.Entities
{
    public class NotificationSetting
    {
        #region Properties
        public int UserId { get; set; }
        public bool Subscriptions { get; set; }
        public bool RecommendedCourses { get; set; }
        public bool ActivityOnMyComment { get; set; }
        public bool RepliesToMyComments { get; set; }
        #endregion

        #region RelationProperties
        public AppUser User { get; set; }
        #endregion
    }
}

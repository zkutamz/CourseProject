namespace LMS.Model.Request.NotificationSettingDTOs
{
    public class NotificationSettingEditDTO
    {
        public int UserId { get; set; }
        public bool Subscriptions { get; set; }
        public bool RecommendedCourses { get; set; }
        public bool ActivityOnMyComment { get; set; }
        public bool RepliesToMyComments { get; set; }
    }
}

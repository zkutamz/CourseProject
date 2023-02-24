namespace LMS.Model.Request.PrivacySettingDTOs
{
    public class PrivacySettingEditDTO
    {
        public int UserId { get; set; }
        public bool ShowYourProfileOnSearchEngines { get; set; }
        public bool ShowCoursesYouAreTakingOnYourProfilePage { get; set; }
    }
}

namespace LMS.Model.Response.AppUserDTOs
{
    public class AppUserForCourseDetailDTO : AppUserBasicDTO
    {
        public int ProfileViewCount { get; set; }
        public string ProfileImageUrl { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
    }
}

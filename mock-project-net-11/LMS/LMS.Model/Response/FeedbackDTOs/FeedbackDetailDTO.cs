using LMS.Model.Response.AppUserDTOs;

namespace LMS.Model.Response.FeedbackDTOs
{
    class FeedbackDetailDTO : FeedbackDTO
    {
        public string Answer { get; set; }
        public AppUserDTO User { get; set; }
        public string ScreenShot { get; set; }
    }
}

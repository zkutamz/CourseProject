using System;

namespace LMS.Model.Response.NotificationDTOs
{
    public class NotificationsDTO
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string Header { get; set; }
        public string ImgURL { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

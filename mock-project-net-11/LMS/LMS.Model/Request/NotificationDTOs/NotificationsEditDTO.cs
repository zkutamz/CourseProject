using LMS.Model.Response.NotificationDTOs;
using System;

namespace LMS.Model.Request.NotificationDTOs
{
    public class NotificationsEditDTO : NotificationsDTO
    {
        public int UserId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}

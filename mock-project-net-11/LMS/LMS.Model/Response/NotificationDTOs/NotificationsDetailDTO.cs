
using System;
using LMS.Model.Response.AppUserDTOs;

namespace LMS.Model.Response.NotificationDTOs
{
    public class NotificationsDetailDTO : NotificationsDTO
    {
        public AppUserDTO User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.NotificationDTOs
{
    public class NotificationsCreateDTO
    {
        [Required(ErrorMessage ="Detail Notification is required")]     
        public string Details { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Message Notification is required")]
        public string Message { get; set; }
        [Required(ErrorMessage = "Header Notification is required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Header { get; set; }
    }
}

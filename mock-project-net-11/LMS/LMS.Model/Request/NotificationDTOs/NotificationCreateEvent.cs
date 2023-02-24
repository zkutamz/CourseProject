using LMS.Model.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Request.NotificationDTOs
{
    public class NotificationCreateEvent
    {
        public int? UserID { get; set; }// User login current.
        public int? CourseID { get; set; }// Course is Interactived.
        public int? CommentID { get; set; }// Course comment is Interactived.
        public TypeNotification TypeNotification { get; set; }
    }
}

using LMS.Model.Response.AppUserDTOs;
using System;

namespace LMS.Model.Response.UserSubscriberDTOs
{
    public class UserSubscriberDTO : UserSubscriberBasicDTO
    {
        public AppUserSubscriberDTO User { get; set; }
        public AppUserSubscriberDTO Subscriber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

using System;

namespace LMS.Model.Request.AppUserDTOs
{
    public class AppUserEditDTO
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Intro { get; set; }
        public string PhoneNumber { get; set; } 
        public int RoleId { get; set; }
        public bool LockoutEnabled { get; set; }
        #endregion
    }
}

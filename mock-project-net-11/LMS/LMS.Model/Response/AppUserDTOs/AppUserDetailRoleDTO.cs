using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.AppUserDTOs
{
    public class AppUserDetailRoleDTO:AppUserDTO
    {
        public string RoleName { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}

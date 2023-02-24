using LMS.Model.Response.AppUserDTOs;
using System;

namespace LMS.Model.Response.AuthenticationDTOs
{
    public class AuthenticationResponse
    {
#nullable enable
        public string? Token { get; set; }
#nullable disable

        public string Roles { get; set; }

        public AppUserDTO User { get; set; }

        public DateTime Expires { get; set; }
    }
}

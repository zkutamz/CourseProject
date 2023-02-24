using System;
using System.Collections.Generic;
using System.Text;
using LMS.Model.Response.AppUserDTOs;

namespace LMS.Model.Response.ChatDTOs
{
    public class ChatSearchResponse
    {
        public int Id { get; set; }
        
        public AppUserDTO  Receiver { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using LMS.Model.Response.AppUserDTOs;
using LMS.Repository.Entities;

namespace LMS.Model.Response.ChatDTOs
{
    public class ChatDTO
    {
        public int Id { get; set; }

        public AppUserDTO Receiver { get; set; }

        public List<Message> Messages { get; set; }
    }
}

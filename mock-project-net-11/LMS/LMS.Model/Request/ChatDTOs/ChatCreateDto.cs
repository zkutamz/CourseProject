using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Request.ChatDTOs
{
    public class ChatCreateDto
    {
        public int ReceiverId { get; set; }
        public int CurrentUserId { get; set; }
    }
}

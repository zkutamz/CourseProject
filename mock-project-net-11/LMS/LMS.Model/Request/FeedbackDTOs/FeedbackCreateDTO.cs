using LMS.Repository.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace LMS.Model.Request.FeedbackDTOs
{
    public class FeedbackCreateDTO
    {
        public string Email { get; set; }
        public string Description { get; set; }
        public IFormFile ScreenShot { get; set; }
        public int UserId { get; set; }
    }
}

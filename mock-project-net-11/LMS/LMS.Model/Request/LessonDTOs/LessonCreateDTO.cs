using System;
using System.Collections.Generic;
using LMS.Model.Request.AttachmentDTOs;
using LMS.Repository.Entities;
using Microsoft.AspNetCore.Http;

namespace LMS.Model.Request.LessonDTOs
{
    public class LessonCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int TotalTime { get; set; }
        public bool IsPublic { get; set; }
        public int SectionId { get; set; }
        public string EmbeddedCode { get; set; }
        public string VideoUrl { get; set; }
        public List<AttachmentCreateDTO> Attachments { get; set; }
        public string ExternalUrl { get; set; }
        public int Position { get; set; }
    }
}

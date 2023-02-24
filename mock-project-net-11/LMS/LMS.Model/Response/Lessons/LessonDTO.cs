using LMS.Model.Request.AttachmentDTOs;
using LMS.Repository.Entities;
using System;
using System.Collections.Generic;

namespace LMS.Model.Response.Lessons
{
    public class LessonDTO : LessonBasicDTO
    {
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string EmbeddedCode { get; set; }
        public bool IsPublic { get; set; }
        public List<Attachment> Attachments { get; set; }
        public int SectionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}

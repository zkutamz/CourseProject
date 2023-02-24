using LMS.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.SearchDTOs
{
    public class SearchDTO
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Announcement { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Requirement { get; set; }
        public bool Feature { get; set; }
        public int ViewCount { get; set; }
        public int TotalDuration { get; set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public int CertificateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Dictionary<string, int>> TopicCount { get; set; }
        #endregion
    }
}

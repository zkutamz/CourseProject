using LMS.Repository.Enums;
using System;

namespace LMS.Model.Request.CourseDTOs
{
    public class CourseEditDTO
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
        public int TotalDuration { get; set; }
        public string Requirement { get; set; }
        public bool Feature { get; set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        #endregion
    }
}

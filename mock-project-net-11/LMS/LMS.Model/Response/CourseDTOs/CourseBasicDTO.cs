using System;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseBasicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ThumbNailUrl { get; set; }
        public int ViewCount { get; set; }
        public int TotalDuration { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double AverageRate { get; set; }
    }
}

using System;

namespace LMS.Model.Response.EnrollCourses
{
    public class EnrollCourseBasicDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

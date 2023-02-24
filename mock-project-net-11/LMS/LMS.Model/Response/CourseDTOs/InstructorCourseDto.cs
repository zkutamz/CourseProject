using LMS.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CourseDTOs
{
    public partial class InstructorCourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? PublishDate { get; set; }
        public int Sales { get; set;}
        public int Parts { get; set;}
        public string CategoryName { get; set; }
        public CourseStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

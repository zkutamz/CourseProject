using LMS.Model.Response.CourseDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.AppUserDTOs
{
    public class AppUserSubscriberDTO : AppUserBasicDTO
    {
        public string ProfileImageUrl { get; set; }
        public int TotalStudents { get; set; }
        public int TotalCourses { get => Courses.Count; }

        public List<CourseWithEnrollCoursesDTO> Courses { get; set; }
    }
}

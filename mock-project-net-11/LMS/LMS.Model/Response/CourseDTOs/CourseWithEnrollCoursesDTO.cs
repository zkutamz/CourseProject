using LMS.Model.Response.EnrollCourses;
using System.Collections.Generic;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseWithEnrollCoursesDTO
    {
        public List<EnrollCourseBasicDTO> EnrollCourses { get; set; }
    }
}

using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CourseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.EnrollCourses
{
   public class EnrollCourseReviewDTO
    {
        public int Id { get; set; }
        public AppUserNameDTO AppUser { get; set; }
        public CourseTitleDTO Course { get; set; }
    }
}

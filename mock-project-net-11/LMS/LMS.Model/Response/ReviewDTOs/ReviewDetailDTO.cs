using LMS.Model.Response.EnrollCourses;
using System;

namespace LMS.Model.Response.ReviewDTOs
{
    public class ReviewDetailDTO : ReviewDTO
    {
        public EnrollCourseReviewDTO EnrollCourse { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
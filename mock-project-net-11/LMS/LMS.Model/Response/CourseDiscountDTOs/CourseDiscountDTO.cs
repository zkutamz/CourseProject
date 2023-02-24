using LMS.Model.Response.CourseDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CourseDiscountDTOs
{
    public class CourseDiscountDTO
    {
        public CourseDTO courseDTO { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }

    }
}

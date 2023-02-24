using LMS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseForInstructorAnlyicDTO
    {
        public string Title { get; set; }
        public string ThumbNailUrl { get; set; }
        public int TotalPurchase { get; set; }
        public int TotalComment { get; set; }
        public int TotalView { get; set; }
        public List<CourseComment> CourseComments { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}

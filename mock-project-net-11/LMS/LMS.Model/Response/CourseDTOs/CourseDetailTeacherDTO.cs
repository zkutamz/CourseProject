using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.FAQs;
using LMS.Model.Response.OrderDetailDTOs;
using LMS.Repository.Enums;
using System;
using System.Collections.Generic;
using LMS.Model.Response.CourseCommentDTOs;
using LMS.Model.Response.SectionDTOs;
using LMS.Model.Response.CertificateDTOs;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseDetailTeacherDTO
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
        public string Requirement { get; set; }
        public bool Feature { get; set; }
        public int ViewCount { get; set; }
        public int TotalDuration { get; set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        #endregion

        #region Navigational Properties

        public List<FAQDTO> FAQs { get; set; }

        public List<SectionDTO> Sections { get; set; }

        public List<CourseCommentDTO> CourseComments { get; set; }

        public List<OrderDetailDTO> OrderDetails { get; set; }

        public List<EnrollCourseDTO> EnrollCourses { get; set; }

        public CertificateDTO Certificate { get; set; }

        #endregion
    }
}

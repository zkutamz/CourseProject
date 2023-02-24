using LMS.Model.Response.CategoryDTOs;
using LMS.Model.Response.CertificateDTOs;
using LMS.Model.Response.CourseCommentDTOs;
using LMS.Model.Response.FAQs;
using LMS.Model.Response.SectionDTOs;
using LMS.Repository.Enums;
using System.Collections.Generic;
// TODO doi prop dto
namespace LMS.Model.Response.CourseDTOs
{
    public class CourseDetailStudentDTO : CourseOverviewDTO
    {
        #region Properties
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Announcement { get; set; }
        public bool Feature { get; set; }
        public int ViewCount { get; set; }
        public Level Level { get; set; }
        #endregion

        #region Navigational Properties

        public List<FAQDTO> FAQs { get; set; }

        public List<CourseCommentDTO> CourseComments { get; set; }

        //public CertificateDTO Certificate { get; set; }
        public CategoryDTO Category { get; set; }

        #endregion
    }
}

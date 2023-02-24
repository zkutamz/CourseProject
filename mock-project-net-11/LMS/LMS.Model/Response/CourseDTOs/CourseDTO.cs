using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CategoryDTOs;
using LMS.Repository.Enums;
using System;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseDTO : CourseBasicDTO
    {
        #region Properties

        public string Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Announcement { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Requirement { get; set; }
        public bool Feature { get; set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public AppUserDTO AppUser { get; set; }
        public int CertificateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsBestSeller { get; set; } = false;

        #endregion
    }
}

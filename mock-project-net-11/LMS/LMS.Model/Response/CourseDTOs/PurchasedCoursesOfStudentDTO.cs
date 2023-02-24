using LMS.Repository.Entities;
using LMS.Repository.Enums;
using System;
using System.Collections.Generic;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CategoryDTOs;
using LMS.Model.Response.EnrollCourses;

namespace LMS.Model.Response.CourseDTOs
{
    public class PurchasedCoursesOfStudentDTO
    {
        //Course
        public int Id { get; set; }
        public string Title { get; set; }
        //public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestSeller { get; set; }
        //public decimal OriginalPrice { get; set; }
        //public string ImageUrl { get; set; }
        //public string Announcement { get; set; }
        //public DateTime? PublishedDate { get; set; }
        //public string Requirement { get; set; }
        //public bool Feature { get; set; }
        //public int ViewCount { get; set; }
        //public int TotalDuration { get; set; }
        //public Level Level { get; set; }
        //public CourseStatus CourseStatus { get; set; }
        //public int InstructorId { get; set; }
        //public int CategoryId { get; set; }
        //public int CertificateId { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }


        ////AppUser

        //public AppUserDTO AppUser { get; set; }

        ////Category
        //public CategoryDTO Category { get; set; }

        //EnrollCourse 
        //public CourseDTO Course { get; set; }
        //public DateTime PurchaseDate { get; set; }
        //public decimal Price { get; set; }
        public CategoryDTO Category { get; set; }
        public AppUserNameDTO AppUser { get; set; }
        //public List<EnrollCourseDTO> EnrollCourses { get; set; }
    }
}

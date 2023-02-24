using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.ReviewDTOs;
using LMS.Model.Response.SectionDTOs;
using System;
using System.Collections.Generic;

namespace LMS.Model.Response.CourseDTOs
{
    /// <summary>
    /// This DTO summarizes information about a course.
    /// Use in: Course overview tab in Course Study page.
    /// </summary>
    public class CourseOverviewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Requirement { get; set; }
        public string WhatLearn { get; set; }
        public int TotalDuration { get; set; }
        public int TotalReviewed { get; set; }
        public int TotalStudents { get; set; }

        public AppUserBasicDTO AppUser { get; set; }
        //public List<EnrollCourseDTO> EnrollCourses { get; set; }
        public ReviewFeaturedDTO FeaturedReview { get; set; }
        public List<SectionBasicDTO> Sections { get; set; }
    }
}

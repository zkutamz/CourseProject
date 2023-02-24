using System;
using System.Collections.Generic;
using LMS.Repository.Enums;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class stores information about a course.
    /// </summary>
    public class Course : BaseEntity
    {
        #region Properties

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string VideoUrl { get; set; }
        public string EmbeddedCode { get; set; }
        public string Announcement { get; set; }
#nullable enable
        public DateTime? PublishedDate { get; set; }
#nullable disable
        public string Requirement { get; set; }
        public bool Feature { get; set; } = false;
        public bool RequiredLogIn { get; set; } = false;
        public bool RequireEnroll { get; set; } = false;
        public string WhatLearn { get; set; }
        public int ViewCount { get; set; }
        public int TotalDuration { get; set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public string AudioLanguage { get; set; }
        public string CloseCaption { get; set; }
        public string IntroOverviewUrl { get; set; }
        /// <summary>
        /// This property is for course thumbnail image
        /// </summary>
        public string ThumbNailUrl { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// 
        /// </summary>
        public List<EnrollCourse> EnrollCourses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Section> Sections { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CourseComment> CourseComments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FavoriteCourse> FavoriteCourses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Visitor> Visitors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AppUser AppUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Category Category { get; set; }
        public IList<CourseDiscount> CourseDiscounts { get; set; }
        public IList<ShoppingCart> ShoppingCarts { get; set; }
        public Certificate Certificate { get; set; }
        #endregion
    }
}

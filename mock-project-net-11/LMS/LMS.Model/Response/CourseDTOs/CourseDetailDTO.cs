using System;
using LMS.Model.Response.AppUserDTOs;
using LMS.Repository.Enums;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseDetailDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
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
        public string AudioLanguage { get; set; }
        
        public string ThumbNailUrl { get; set; }
        public string VideoUrl { get; set; }
        public decimal Rating { get; set; }
        public int TotalRatings { get; set; }
        public int TotalEnrolled { get; set; }
        public bool IsFavorite { get; set; }
        public int CategoryId { get; set; }
        public string CloseCaption { get; set; }
        public decimal OriginalPrice { get; set; }
#nullable enable
        public bool? HasUpVote { get; set; }
        public bool? HasDownVote { get; set; }
#nullable disable
        public DateTime UpdatedAt { get; set; }

        public AppUserForCourseDetailDTO AppUser { get; set; }

    }
}

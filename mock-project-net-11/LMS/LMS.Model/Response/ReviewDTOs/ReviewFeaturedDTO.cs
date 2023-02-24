using LMS.Model.Response.AppUserDTOs;
using System;

namespace LMS.Model.Response.ReviewDTOs
{
    /// <summary>
    /// This DTO has basic information of an featured review of a course.
    /// Used in:
    ///     + Feature review in course overview in course study page.
    /// </summary>
    public class ReviewFeaturedDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public AppUserReviewDTO User { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

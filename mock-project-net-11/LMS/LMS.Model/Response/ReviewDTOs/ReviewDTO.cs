using LMS.Model.Response.AppUserDTOs;
using System;

namespace LMS.Model.Response.ReviewDTOs
{
    public class ReviewDTO
    {
        #region Properties

        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int EnrollCourseId { get; set; }
        #endregion
    }
}
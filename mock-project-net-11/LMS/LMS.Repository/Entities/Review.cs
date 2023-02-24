using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// Review: Content, Rating, CourseId, AppUserId, 1-n: EnrollCourse
    /// </summary>
    public class Review : BaseEntity
    {
        #region Properties

        public string Content { get; set; }
        public int Rating { get; set; }
        public int HelpfulnessRating { get; set; }

        #endregion

        #region Navigational Properties 
        
        public int EnrollCourseId { get; set; }
        public EnrollCourse EnrollCourse { get; set; }
        public List<UserVotesReview> UserVotesReviews { get; set; }

        #endregion
    }
}

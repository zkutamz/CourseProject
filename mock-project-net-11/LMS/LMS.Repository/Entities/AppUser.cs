using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class stores information about a user.
    /// </summary>
    public class AppUser : IdentityUser<int>
    {
        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDelete { get; set; }
        public string VerificationToken { get; set; }
        public string ResetToken { get; set; }


#nullable enable
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public DateTime? Verified { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Intro { get; set; }

        public string? Headline { get; set; }

        public string? ProfileLink { get; set; }

        public string? FacebookLink { get; set; }

        public string? TwitterLink { get; set; }

        public string? LinkedInLink { get; set; }

        public string? YoutubeLink { get; set; }
#nullable disable

        public int ProfileViewCount { get; set; }

        public int UpVote { get; set; }

        public int DownVote { get; set; }

        #endregion

        #region Navigational Properties

        /// <summary>
        /// Relationship 1-n: EnrollCourse
        /// </summary>
        public List<EnrollCourse> EnrollCourses { get; set; }
        public List<AssignmentSubmissions> AssignmentSubmissions { get; set; }
        public CourseComment CourseComment { get; set; }
        public List<FavoriteCourse> FavoriteCourses { get; set; }
        public List<OrderHeader> OrderHeaders { get; set; }
        public List<LessonCompletion> LessonCompletions { get; set; }
        public List<LearningPeriods> LearningPeriods { get; set; }
        public List<Notifications> Notifications { get; set; }
        public List<Course> Courses { get; set; }
        public List<Specializations> Specializations { get; set; }
        public List<SectionCompletion> SectionCompletions { get; set; }
        public List<UserSubcriber> UserSubscribeds { get; set; }
        public List<UserSubcriber> InstructorSubscribeds { get; set; }
        public List<Feedback> Feedacks { get; set; }
        public IList<ChatUser> ChatUser { get; set; }
        public List<UserCertificate> UserCertificates { get; set; }
        public NotificationSetting NotificationSetting { get; set; }
        public PrivacySetting PrivacySetting { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public List<Visitor> Visitors { get; set; }
        public IList<CoursePromotion> CoursePromotions { get; set; }
        public IList<ShoppingCart> ShoppingCarts { get; set; }
        public List<UserVotesReview> UserVotesReviews { get; set; }
        public List<Reaction> Reactions { get; set; }
        public List<Discussion> Discussions { get; set; }
        public List<UserLoginToken> UserLoginTokens { get; set; } = new List<UserLoginToken>();
        public List<UserVoter> UserVoters { get; set; }

        #endregion
    }
}

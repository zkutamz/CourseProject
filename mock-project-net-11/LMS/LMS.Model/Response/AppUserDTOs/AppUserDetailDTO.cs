using System.Collections.Generic;
using LMS.Model.Request.LearningPeriodDTOs;
using LMS.Model.Response.AssignmentSubmissionsDTOs;
using LMS.Model.Response.CourseCommentDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.CourseFavoriteDTOs;
using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.LessonCompletions;
using LMS.Model.Response.NotificationDTOs;
using LMS.Model.Response.OrderHeaderDTOs;
using LMS.Model.Response.SectionCompletionDTOs;
using LMS.Model.Response.SpecializationDTOs;

namespace LMS.Model.Response.AppUserDTOs
{
    public class AppUserDetailDTO : AppUserDTO
    {
        public List<EnrollCourseDTO> EnrollCourses { get; set; }
        public List<AssignmentSubmissionsDTO> AssignmentSubmissions { get; set; }
        public CourseCommentDTO CourseComment { get; set; }
        public List<CourseFavoriteDTO> FavoriteCourses { get; set; }
        public List<OrderHeaderDTO> OrderHeaders { get; set; }
        public List<LessonCompletionDTO> LessonCompletions { get; set; }
        public List<LearningPeriodDTO> LearningPeriods { get; set; }
        public List<NotificationsDTO> Notifications { get; set; }
        public List<CourseDTO> Courses { get; set; }
        public List<SpecializationDTO> Specializations { get; set; }
        public List<SectionCompletionDTO> SectionCompletions { get; set; }
    }
}

using LMS.Model.Response.AppUserDTOs;
using System.Collections.Generic;
using LMS.Model.Response.CourseDTOs;

namespace LMS.Model.Response.CourseCommentDTOs
{
    public class CourseCommentDetailDTO
    {
        public string Content { get; set; }
        public bool IsModified { get; set; }
        public int CourseId { get; set; }

        public int? UserId { get; set; }
        public int? ParentCommentId { get; set; }

        public AppUserDTO User { get; set; }
        public CourseDTO Course { get; set; }
        public CourseCommentDTO ParentComment { get; set; }
        public List<CourseCommentDTO> ChildCourseComments { get; set; }
    }
}

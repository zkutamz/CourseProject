using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class store comments of cources
    /// </summary>
    public class CourseComment : BaseEntity
    {
        #region Properties
        public string Content { get; set; }
        public bool IsModified { get; set; }
        public int CourseId { get; set; }
#nullable enable
        public int? UserId { get; set; }
        public int? ParentCommentId { get; set; }
#nullable disable

        #endregion

        #region Navigations
        public AppUser User { get; set; }
        public Course Course { get; set; }
        public CourseComment ParentComment { get; set; }
        public List<CourseComment> ChildCourseComments { get; set;}
        #endregion
    }
}

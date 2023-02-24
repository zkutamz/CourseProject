using System;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// Configuration for LessonCompletion entity
    /// </summary>
    public class LessonCompletion : BaseEntity
    {
        #region Properties
        public DateTime CompletedDate { get; set; }
        #endregion

        #region RelationProperties
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public Lesson Lession { get; set; }
        public AppUser User { get; set; } 
        #endregion
    }
}

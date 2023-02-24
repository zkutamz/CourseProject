namespace LMS.Repository.Entities
{
    /// <summary>
    /// Notes: 1-n: EnrollCourse, 1-n: Lesson
    /// </summary>
    public class Notes:BaseEntity
    {
        #region Properties
        public string Content { get; set; }
        #endregion

        #region Navigational Properties
        public int EnrollCourseId { get; set; }
        public EnrollCourse EnrollCourse { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        #endregion
    }
}

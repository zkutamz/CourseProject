namespace LMS.Repository.Entities
{
    public class Attachment : BaseEntity
    {
        #region Properties
        public string AttachmentUrl { get; set; }
        public long Size { get; set; }
        public int? LessonId { get; set; }
        public int? AssignmentId { get; set; }
        #endregion

        #region Relationship
        public Assignment Assignment { get; set; }
        //public Lesson Lesson { get; set; }
        #endregion
    }
}

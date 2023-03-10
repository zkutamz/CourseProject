namespace LMS.Model.Response.CourseCommentDTOs
{
    public class CourseCommentDTO
    {
        public string Content { get; set; }
        public bool IsModified { get; set; }
        public int CourseId { get; set; }

        public int? UserId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}

namespace LMS.Model.Request.ReviewDTOs
{
    public class ReviewCreateDTO
    {
        #region Properties

        public string Content { get; set; }
        public int Rating { get; set; }
        public int CourseId { get; set; }

        #endregion
    }
}
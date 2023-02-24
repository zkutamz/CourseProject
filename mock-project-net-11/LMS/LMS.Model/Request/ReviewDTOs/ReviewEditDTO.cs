namespace LMS.Model.Request.ReviewDTOs
{
    public class ReviewEditDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int EnrollCourseId { get; set; }
        public int HelpfulnessLevel { get; set; }
    }
}
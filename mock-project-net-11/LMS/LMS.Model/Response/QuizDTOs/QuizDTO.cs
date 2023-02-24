using LMS.Model.Response.SectionDTOs;

namespace LMS.Model.Response.QuizDTOs
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTime { get; set; }
        public bool IsComplete { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public bool IsExposedQuestion { get; set; }
    }
}

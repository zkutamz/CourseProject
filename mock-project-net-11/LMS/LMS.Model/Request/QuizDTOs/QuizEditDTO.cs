using Microsoft.AspNetCore.Http;

namespace LMS.Model.Request.QuizDTOs
{
    public class QuizEditDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public int TotalTime { get; set; }
        public bool IsPublic { get; set; }
        public bool IsExposedQuestion { get; set; }
    }
}

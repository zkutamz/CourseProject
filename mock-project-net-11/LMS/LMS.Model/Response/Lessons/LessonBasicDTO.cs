namespace LMS.Model.Response.Lessons
{
    public class LessonBasicDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalTime { get; set; }
        public int Position { get; set; }
        public bool IsComplete { get; set; }
    }
}
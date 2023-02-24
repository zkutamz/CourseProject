namespace LMS.Model.Response.AssignmentDTOs
{
    public class AssignmentDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int TotalTime { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int? SectionId { get; set; }
    }
}

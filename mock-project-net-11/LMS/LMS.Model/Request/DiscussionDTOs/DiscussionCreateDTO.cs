namespace LMS.Model.Request.DiscussionDTOs
{
    public class DiscussionCreateDTO
    {
        public string Content { get; set; }

#nullable enable
        public int? ParentId { get; set; }
#nullable disable
    }
}

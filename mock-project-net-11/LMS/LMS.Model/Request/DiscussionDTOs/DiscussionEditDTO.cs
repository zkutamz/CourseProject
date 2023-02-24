namespace LMS.Model.Request.DiscussionDTOs
{
    public class DiscussionEditDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

#nullable enable
        public int? ParentId { get; set; }
#nullable disable
    }
}

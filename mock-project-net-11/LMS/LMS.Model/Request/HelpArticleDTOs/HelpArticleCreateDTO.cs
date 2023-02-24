namespace LMS.Model.Request.HelpArticleDTOs
{
    public class HelpArticleCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int HelpTopicId { get; set; }
       
    }
}

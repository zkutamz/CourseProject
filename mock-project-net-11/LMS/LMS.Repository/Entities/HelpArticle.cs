namespace LMS.Repository.Entities
{
    public class HelpArticle : BaseEntity
    {
        #region Properties
        public string Title { get; set; }
        public string Content { get; set; }
        #endregion

        #region Relation Properties
        public int HelpTopicId { get; set; }
        public HelpTopic HelpTopic { get; set; } 
        #endregion
    }
}

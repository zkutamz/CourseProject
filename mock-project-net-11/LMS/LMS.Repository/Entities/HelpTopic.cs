using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class HelpTopic : BaseEntity
    {
        #region Properties
        public string Title { get; set; }
        public string IconURL { get; set; }
        public string Description { get; set; }
        #endregion

        #region Relation Properties
        public int HelpId { get; set; }
        public Help Help { get; set; }
        public IList<HelpArticle> HelpArticles { get; set; } 
        #endregion
    }
}

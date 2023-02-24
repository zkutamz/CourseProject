using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class Help : BaseEntity
    {
        #region Properties
        public string UserContent { get; set; }
        public bool IsPublished { get; set; }
        #endregion

        #region Relation Properties
        public IList<FAQ> FAQs { get; set; }
        public IList<HelpTopic> HelpTopics { get; set; } 
        #endregion
    }
}

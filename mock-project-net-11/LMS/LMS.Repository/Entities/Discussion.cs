using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class Discussion : BaseEntity
    {
        #region Properties
        public string Content { get; set; }
#nullable enable
        public int? ParentId { get; set; }
#nullable disable
        #endregion

        #region Navigational Properties
        public IList<Reaction> Reactions { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }

        public IList<Discussion> ChildDiscussions { get; set; }
        public Discussion ParentDiscussions { get; set; }
        #endregion
    }
}

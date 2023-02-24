namespace LMS.Repository.Entities
{
    public class Reaction
    {
        #region Properties
        public int DiscussionId { get; set; }

        public int UserId { get; set; }

        // Type of reaction (false: dislike, true: like)
        public bool Type { get; set; }
        #endregion

        #region Navigational Properties
        public AppUser User { get; set; }
        public Discussion Discussion { get; set; }
        #endregion
    }
}

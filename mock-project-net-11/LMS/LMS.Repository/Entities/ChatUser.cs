namespace LMS.Repository.Entities
{
    public class ChatUser
    {
        #region Properties
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public bool IsMute { get; set; }

        #endregion

        #region Relationship Properties
        public Chat Chat { get; set; }
        public AppUser User { get; set; } 
        #endregion

    }
}

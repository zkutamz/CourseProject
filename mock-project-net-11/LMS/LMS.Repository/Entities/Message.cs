namespace LMS.Repository.Entities
{
    /// <summary>
    /// Message content between two user
    /// </summary>
    public class Message : BaseEntity
    {
        #region Properties
        // Content of message
        public string Content { get; set; }
        // Message is read
        public bool IsRead { get; set; }

        #endregion
        #region Relationship Properties
        public int ChatId { get; set; }
        public Chat Chats { get; set; }
        #endregion

    }
}

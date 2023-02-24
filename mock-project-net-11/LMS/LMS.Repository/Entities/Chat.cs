using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// Relationship chat between two user
    /// </summary>
    public class Chat : BaseEntity
    {
        /// <summary>
        /// Chat is mute by someone User
        /// </summary>

        #region Properties
        public bool IsBlock { get; set; }
        #endregion

        #region Relationship properties
        public IList<ChatUser> ChatUsers { get; set; }
        public IList<Message> Messages { get; set; }
        #endregion
    }
}
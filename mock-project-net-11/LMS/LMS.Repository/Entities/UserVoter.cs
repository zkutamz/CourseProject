using System;

namespace LMS.Repository.Entities
{
    public class UserVoter
    {
        public int UserId { get; set; }
        public int VoterId { get; set; }
        public bool IsUpvote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AppUser AppUser { get; set; }
    }
}

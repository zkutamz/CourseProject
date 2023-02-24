namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class stores user's votes for reviews helpfulness
    /// </summary>
    public class UserVotesReview : BaseEntity
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public bool IsHelpful { get; set; }
    }
}

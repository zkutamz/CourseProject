using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class UserVotesReviewRepository : Repository<UserVotesReview>, IUserVotesReviewRepository
    {
        public UserVotesReviewRepository(
            LMSApplicationContext context,
            ILogger<Repository<UserVotesReview>> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }
    }
}

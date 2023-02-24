using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository.Paging;

namespace LMS.Repository.Repositories
{
    public class DiscussionRepository : Repository<Discussion>, IDiscussionRepository
    {
        private readonly LMSApplicationContext _context;
        private readonly ILogger<Repository<Discussion>> _logger;

        public DiscussionRepository(LMSApplicationContext context,
            ILogger<Repository<Discussion>> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PaginatedList<Discussion>> GetAllDiscussionAsync(int userId, PagingRequest pagingRequest)
        {
            try
            {
                var result = _context.Discussions
                    .Include(x => x.Reactions)
                    .Include(x => x.User)
                    .Include(x => x.ChildDiscussions)
                    .ThenInclude(x => x.User)
                    .Include(x => x.ChildDiscussions)
                    .ThenInclude(x => x.Reactions)
                    .Where(x => x.UserId == userId && x.ParentId == null)
                    .AsNoTracking();
                return await PaginatedList<Discussion>.ToPaginatedListAsync(result, pagingRequest.PageNumber, pagingRequest.PageSize); ;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(GetAllDiscussionAsync)}. {e.Message}");
                throw;
            }
        }

        public async Task<Discussion> GetDiscussionWithReactionAsync(int discussionId)
        {
            try
            {
                var result = await _context.Discussions
                    .Include(x => x.Reactions)
                    .Include(x => x.User)
                    .Include(x => x.ChildDiscussions).ThenInclude(x => x.User)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == discussionId);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(GetDiscussionWithReactionAsync)}. {e.Message}");
                throw;
            }
        }
    }
}

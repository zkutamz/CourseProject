using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{

    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(LMSApplicationContext context, ILogger<Repository<Feedback>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }

        public async Task<PaginatedList<Feedback>> GetAllFeedbackPaging(PagingRequest pagingRequest)
        {
            try
            {
                var query = Context.Feedbacks.Where(f=>f.IsDelete == false).OrderByDescending(f=>f.CreatedAt);
                return await PaginatedList<Feedback>.ToPaginatedListAsync(query,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedList<Feedback>> GetAllFeedbackUserByIdPaging(int userId, PagingRequest pagingRequest)
        {
            var query = Context.Feedbacks.Where(f => f.IsDelete == false && f.UserId == userId)
                                          .OrderByDescending(f => f.CreatedAt);
            return await PaginatedList<Feedback>.ToPaginatedListAsync(query,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            try
            {
                var feedback = await Context.Feedbacks.Where(f => f.IsDelete == false && f.Id == id).FirstOrDefaultAsync();
                return feedback ?? new Feedback();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

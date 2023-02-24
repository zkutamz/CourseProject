using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class FAQRepository : Repository<FAQ>, IFAQRepository
    {
        public FAQRepository(LMSApplicationContext context, ILogger<FAQRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }

        public async Task<List<FAQ>> GetAllFAQAsync()
        {
            var fAQs = await Context.FAQs.Where(r => r.IsDelete == false).ToListAsync();
            if (fAQs == null)
                return new List<FAQ>();
            return fAQs;
        }

        public async Task<FAQ> GetFAQById(int? id)
        {
            var fAQ = await Context.FAQs.FirstOrDefaultAsync(r => r.IsDelete == false && r.Id == id);
            if (fAQ == null)
                return new FAQ();
            return fAQ;
        }

        public async Task<PaginatedList<FAQ>> GetFAQPaging(PagingRequest pagingRequest)
        {
            var query = Context.FAQs.Where(r => r.IsDelete == false);

            return await PaginatedList<FAQ>.ToPaginatedListAsync(query,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
        }
    }
}

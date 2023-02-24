using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class HelpArticleRepository : Repository<HelpArticle>, IHelpArticleRepository
    {
        public HelpArticleRepository(LMSApplicationContext context, ILogger<HelpArticleRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {

        }
        public List<HelpArticle> GetAllArticle(int helpTopicId)
        {
            try
            {
                var articles = Context.HelpArticles
                    .Where(x => x.HelpTopicId == helpTopicId).ToList();
                return articles;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetAllArticle));
                throw;
            }
        }
    }
}

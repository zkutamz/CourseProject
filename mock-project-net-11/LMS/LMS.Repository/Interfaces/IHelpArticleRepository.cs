using LMS.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IHelpArticleRepository : IRepository<HelpArticle>
    {
        /// <summary>
        /// Get All Article by help topic id.
        /// </summary>
        /// <param name="helpTopicId">int helpTopicId</param>
        /// <returns>List<HelpArticle></returns>
        List<HelpArticle> GetAllArticle(int helpTopicId);
    }
}

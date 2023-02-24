using LMS.Model.Request.HelpArticleDTOs;
using LMS.Model.Response.HelpArticleDTOs;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.HelpArticleServices
{
    public interface IHelpArticleService
    {
        Task<HelpArticleDetailDTO> GetArticleDetail(int id);
        /// <summary>
        /// Get All Article By Topic
        /// </summary>
        /// <param name="helpTopicId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List HelpActicleDTO</returns>
        Task<PagingResult<HelpArticleDTO>> GetAllArticle(int helpTopicId, PagingRequest pagingRequest);
        /// <summary>
        /// Get All Article By Topic
        /// </summary>
        /// <param name="helpTopicIdt">int helpTopicID</param>
        /// <returns>List<HelpArticleDTO></returns>
        List<HelpArticleDTO> GetAllArticle(int helpTopicID);
        /// <summary>
        /// Create Article
        /// </summary>
        /// <param name="helpArticle"></param>
        /// <returns>HelpArticleDTO</returns>
        Task<HelpArticleDTO> CreateHelpArticle(HelpArticleCreateDTO helpArticle);
        /// <summary>
        /// Delete Article By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true-false</returns>
        Task<bool>DeleteHelpArticle(int id);
        /// <summary>
        /// Update HelpArticle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpArticle"></param>
        /// <returns>true-false</returns>
        Task<bool> UpdateHelpArticle(int id,HelpArticleEditDTO helpArticle);
        /// <summary>
        /// Search for articles constain keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PagingResult<HelpArticleDTO>> GetHelpSearch(string keyword, PagingRequest pagingRequest);
    }
}

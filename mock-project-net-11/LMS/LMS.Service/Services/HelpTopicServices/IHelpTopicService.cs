using LMS.Model.Request.HelpTopicDTOs;
using LMS.Model.Response.HelpTopicDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.HelpTopicServices
{
    public interface IHelpTopicService
    {
        /// <summary>
        /// Get topic detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HelpTopicDetailDTO</returns>
        Task<HelpTopicDetailDTO> GetTopicDetail(int id);

        /// <summary>
        /// Create new help topic
        /// </summary>
        /// <param name="helpTopicCreate"></param>
        /// <returns>New helpTopicId</returns>
        Task<int> CreateHelpTopic(HelpTopicCreateDTO helpTopicCreate);

        /// <summary>
        /// Update help topic
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpTopicEdit"></param>
        /// <returns>True if success</returns>
        Task<bool> UpdateHelpTopic(int id, HelpTopicEditDTO helpTopicEdit);

        /// <summary>
        /// Delete help topic
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        Task<bool> DeleteHelpTopic(int id);
    }
}

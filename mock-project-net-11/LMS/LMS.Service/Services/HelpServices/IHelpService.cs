using LMS.Model.Request.HelpDTOs;
using LMS.Model.Response.HelpDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.HelpServices
{
    public interface IHelpService
    {
        /// <summary>
        /// Get detail of help
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HelpDetailDTO</returns>
        Task<HelpDetailDTO> GetHelpDetail(int id);

        /// <summary>
        /// Create new help
        /// </summary>
        /// <param name="helpCreate"></param>
        /// <returns>New helpId</returns>
        Task<int> CreateHelp(HelpCreateDTO helpCreate);

        /// <summary>
        /// Delete help
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        Task<bool> DeleteHelp(int id);

        /// <summary>
        /// Update help
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpEdit"></param>
        /// <returns>True if success</returns>
        Task<bool> UpdateHelp(int id, HelpEditDTO helpEdit);

        /// <summary>
        /// Get all help
        /// </summary>
        /// <returns>List HelpDTO</returns>
        Task<List<HelpDTO>> GetAllHelp();

        /// <summary>
        /// Get all help published
        /// </summary>
        /// <returns>List HelpDTO</returns>
        Task<List<HelpDTO>> GetAllHelpPublished();
    }
}

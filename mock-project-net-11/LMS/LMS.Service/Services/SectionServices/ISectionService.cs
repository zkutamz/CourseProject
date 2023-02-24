using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Model.Request.SectionDTOs;
using LMS.Model.Response.SectionDTOs;
using LMS.Repository.Paging;

namespace LMS.Service.Services.SectionServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISectionService
    {
        /// <summary>
        /// This method get a paged list of sections.
        /// </summary>
        /// <param name="request">Paging parameters</param>
        /// <returns>A paged list of section DTO objects</returns>
        Task<PagingResult<SectionDTO>> GetSectionDTOsAsync(PagingRequest request = null);

        /// <summary>
        /// This method gets a section base on it ID.
        /// </summary>
        /// <param name="id">ID of a section to filter</param>
        /// <returns>A section detail DTO object</returns>
        Task<SectionDetailDTO> GetSectionDetailDTOAsync(int id);

        /// <summary>
        /// This method creates a new section.
        /// </summary>
        /// <param name="request">A section DTO object contains data to create a section</param>
        /// <returns>A section DTO object</returns>
        Task<SectionDTO> CreateSectionAsync(SectionCreateDTO request);

        /// <summary>
        /// This method create new sections.
        /// </summary>
        /// <param name="requests">A list of section DTO objects contain data to create sections</param>
        Task CreateSectionsAsync(List<SectionCreateDTO> requests);

        /// <summary>
        /// This method update an existing section with the provided data.
        /// </summary>
        /// <param name="request">A section object contains data for updating</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> UpdateSectionAsync(SectionEditDTO request);

        /// <summary>
        /// This method search for an existing section and update it total time.
        /// </summary>
        /// <param name="sectionId">Section Id to filter</param>
        /// <param name="totalTime">Total time to add to the section total time</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<int> UpdateSectionTotalTimeAsync(int sectionId, int totalTime);

        /// <summary>
        /// This method delete an existing section from the DB.
        /// </summary>
        /// <param name="id">Section ID to filter</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> DeleteSectionAsync(int id);
        Task<bool> IsExistsAsync(int sectionId);
    }
}
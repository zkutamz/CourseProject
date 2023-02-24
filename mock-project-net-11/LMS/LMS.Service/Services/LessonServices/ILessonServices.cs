using LMS.Model.Request.LessonDTOs;
using LMS.Model.Response.Lessons;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.LessonServices
{
    public interface ILessonServices
    {
        /// <summary>
        /// Get lesson Async
        /// </summary>
        /// <param name="request">PagingRequest</param>
        /// <returns>PagingResult<LessonDTO></returns>
        Task<PagingResult<LessonDTO>> GetLessonAsync(PagingRequest request = null);
        /// <summary>
        /// Get Lesson Detail Async
        /// </summary>
        /// <param name="id">Lesson Id</param>
        /// <returns>LessonDTO</returns>
        Task<LessonDTO> GetLessonDetailAsync(int id);
        /// <summary>
        /// Create Lesson
        /// </summary>
        /// <param name="request"></param>
        /// <returns>LessonDTO</returns>
        Task<LessonDTO> CreateLessonAsync(LessonCreateDTO request);
        /// <summary>
        /// Update Lesson Async
        /// </summary>
        /// <param name="id">Lesson Id</param>
        /// <param name="request"></param>
        /// <returns>true if success</returns>
        Task<LessonEditDTO> UpdateLessonAsync(int id, LessonEditDTO request);
        /// <summary>
        /// Delete Lesson
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if success</returns>
        Task<bool> DeleteLessonAsync(int id);
        /// <summary>
        /// Get lesson by section Id
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>LessonBasicDTO</returns>
        Task<PagingResult<LessonDTO>>GetLessonBySectionId(int sectionId, PagingRequest request);
    }
}

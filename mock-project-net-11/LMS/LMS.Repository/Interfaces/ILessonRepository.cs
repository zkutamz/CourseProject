using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        /// <summary>
        /// Get Lesson by section Id
        /// </summary>
        /// <param name="sectionId"></param>
        /// <returns>List Lesson</returns>
        Task<PaginatedList<Lesson>> GetLessonBySectionId(int sectionId, PagingRequest request);
    }
}

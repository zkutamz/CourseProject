using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Repository.Entities;

namespace LMS.Repository.Interfaces
{
    public interface ISectionRepository : IRepository<Section>
    {
        /// <summary>
        /// This method gets sections of a course and its related information.
        /// </summary>
        /// <param name="courseId">Course Id of type int</param>
        /// <returns>A list of sections</returns>
        Task<List<Section>> GetSectionsForCourseContentAsync(int courseId);

        /// <summary>
        /// This method gets a section of a course and its related information.
        /// </summary>
        /// <param name="courseId">Course Id of type int</param>
        /// <param name="sectionId">Section Id to filter</param>
        /// <returns>A section object</returns>
        Task<Section> GetASectionForCourseAsync(int courseId, int sectionId);
    }
}
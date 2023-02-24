using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    /// <summary>
    /// This class is for get and handle data relative in note table
    /// </summary>
    public class NoteRepository : Repository<Notes>, INoteRepository
    {
        public NoteRepository(LMSApplicationContext context, ILogger<NoteRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {

        }

        /// <summary>
        /// This method is use to get data of note include paginate, fillter, sort
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="courseId"></param>
        /// <param name="lessonId"></param>
        /// <param name="isFilterByAllLesson"></param>
        /// <param name="isSortByOldest"></param>
        /// <returns> paginated list of Note</returns>
        public async Task<PaginatedList<Notes>> GetListNotesAsync(PagingRequest pagingRequest,  int lessonId, int courseId, bool isFilterByAllLesson, bool isSortByOldest)
        {
            //query note data
            var notes = from ec in Context.EnrollCourses
                        join n in Context.Notes
                        on ec.Id equals n.EnrollCourseId
                        join l in Context.Lessons
                        on n.LessonId equals l.Id
                        where ec.CourseId == courseId && n.IsDelete == false
                        select n;
            //filter
            notes = isFilterByAllLesson ? notes : notes.Where(x => x.LessonId == lessonId);
            //sort
            notes = isSortByOldest ? notes.OrderByDescending(x => x.UpdatedAt).ThenBy(x => x.CreatedAt) : notes;

            return await PaginatedList<Notes>.ToPaginatedListAsync(notes, pagingRequest.PageNumber, pagingRequest.PageSize);
        }


    }
}

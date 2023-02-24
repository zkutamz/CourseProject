using LMS.Model.Request.NotesDTOs;
using LMS.Model.Response.NotesDTOs;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.NoteServices
{
    /// <summary>
    /// Handle logic function of note
    /// </summary>
    public interface INoteService
    {
        /// <summary>
        /// Get a note base on note id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        Task<NotesDTO> GetNoteAsync(int noteId);
        /// <summary>
        /// Get list note of a lesson
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="lessonId"></param>
        /// <returns></returns>
        Task<PagingResult<NoteDetailModel>> GetNotesAsync(PagingRequest pagingRequest, int lessonId, int courseId, bool filter, bool sort);
        /// <summary>
        /// This method use to create new Note
        /// </summary>
        /// <param name="notesCreateDTO"></param>
        /// <returns>true if create success ortherwise throw exeption</returns>
        Task<bool> CreateNoteAsync(NotesCreateDTO notesCreateDTO);

        /// <summary>
        /// This method is use to update note
        /// </summary>
        /// <param name="notesEditDTO"></param>
        /// <returns>true if create success ortherwise throw exeption</returns>
        Task<bool> UpdateNoteAsync(NotesEditDTO notesEditDTO);
        /// <summary>
        /// This method use to soft delete note
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        Task<bool> SoftDeleteNoteAsync(int noteId);
        /// <summary>
        /// This method use to get enrolled course id
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <returns>Enroll course id</returns>
        Task<int> GetEnrollCourseIdByCourseIdAndUserId(int courseId, int studentId);
    }
}

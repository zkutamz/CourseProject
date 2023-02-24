using LMS.Model.Constant;
using LMS.Model.Request.NotesDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.NoteServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : BaseController
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        /// <summary>
        /// This API get note data base on noteId param
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns> Note </returns>
        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetNote(int noteId)
        {
            var result = await _noteService.GetNoteAsync(noteId);
            return HandleResult(result, LmsAction.Get);
        }
        /// <summary>
        /// This api get all note in a lesson 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <param name="courseId"></param>
        /// <param name="lessonId"></param>
        /// <returns>return list of note if success, otherwise return error message</returns>
        [HttpGet]
        public async Task<IActionResult> GetNotes([FromQuery] PagingRequest pagingRequest, int courseId, int lessonId, bool filterByAllLesson, bool sortByOldest)
        {
            var result = await _noteService.GetNotesAsync(pagingRequest, courseId, lessonId, filterByAllLesson, sortByOldest);
            return HandleResult(result, LmsAction.Get);
        }


        /// <summary>
        /// This api use to create new Note 
        /// </summary>
        /// <param name="notesCreateDTO"></param>
        /// <returns>Stutus code: 200 if success, otherwise return error message </returns>
        [HttpPost]
        public async Task<IActionResult> CreateNote(NotesCreateDTO notesCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _noteService.CreateNoteAsync(notesCreateDTO);
            return HandleResult(result, LmsAction.Add);
        }
        /// <summary>
        /// This api use to edit existed note
        /// </summary>
        /// <returns>Stutus code: 200 if success, otherwise return error message </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateNote(NotesEditDTO notesEditDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _noteService.UpdateNoteAsync(notesEditDTO);
            return HandleResult(result, LmsAction.Update);
        }
        /// <summary>
        /// This api use to soft delete  note
        /// </summary>
        /// <returns>Stutus code: 200 if success, otherwise return error message </returns>
        /// 
        [HttpPut("SoftDeleteNote")]
        public async Task<IActionResult> SoftDeleteNote(int noteId)
        {
            var result = await _noteService.SoftDeleteNoteAsync(noteId);
            return HandleResult(result, LmsAction.Update);
        }
        /// <summary>
        /// This api use get enroll course id 
        /// </summary>
        /// <returns>Enroll course Id</returns>
        /// 
        [HttpGet("GetEnrollCourseId")]
        public async Task<IActionResult> GetEnrollCourseId(int courseId, int studentId)
        {
            var result = await _noteService.GetEnrollCourseIdByCourseIdAndUserId(courseId, studentId);
            return HandleResult(result, LmsAction.Get);
        }

    }
}

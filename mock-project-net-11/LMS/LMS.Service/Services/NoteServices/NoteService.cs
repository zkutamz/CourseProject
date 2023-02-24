using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.NotesDTOs;
using LMS.Model.Response.NotesDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.NoteServices
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly ILogger<NoteService> _logger;
        public NoteService(IUnitOfWork unitOfWork,
            UserManager<AppUser> userManager,
            IMapper mapper,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            ILogger<NoteService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
       
        public async Task<NotesDTO> GetNoteAsync(int noteId)
        {
            try
            {
                var note = await _unitOfWork.NoteRepository.GetAsync(x => x.Id == noteId && x.IsDelete == false);
                if (note == null)
                {
                    throw new NotFoundException(_responseMessage.NotFound);
                }
                var noteDto = _mapper.Map<NotesDTO>(note);
                return noteDto;
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                throw;
            }
           
           
        }
        public async Task<PagingResult<NoteDetailModel>> GetNotesAsync(PagingRequest pagingRequest, int lessonId, int courseId, bool isFilterByAllLesson, bool isSortByOldest)
        {
            var notes = await _unitOfWork.NoteRepository.GetListNotesAsync(pagingRequest, courseId, lessonId, isFilterByAllLesson, isSortByOldest);
            var listNote = new List<NoteDetailModel>();
            foreach (var note in notes)
            {
                note.Lesson = await _unitOfWork.LessonRepository.GetAsync(x => x.Id == note.LessonId);
                note.EnrollCourse = await _unitOfWork.EnrollCourseRepository.GetAsync(x => x.Id == note.EnrollCourseId);
                var noteDTO = new NoteDetailModel()
                {
                    Id = note.Id,
                    Content = note.Content,
                    CourseId = note.EnrollCourse.CourseId,
                    LessonId = note.LessonId
                };
                listNote.Add(noteDTO);
            }
            var pagingResult = new PagingResult<NoteDetailModel>()
            {
                TotalCount = notes.TotalCount,
                TotalPages = notes.TotalPages,
                PageSize = notes.PageSize,
                CurrentPage = notes.CurrentPage,
                Objects = listNote
            };
            return pagingResult;
        }        public async Task<bool> CreateNoteAsync(NotesCreateDTO notesCreateDTO)
        {
            var note = _mapper.Map<Notes>(notesCreateDTO);
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var createResult = await _unitOfWork.NoteRepository.AddAsync(note);
                var saveResult = await _unitOfWork.SaveAsync();
                if (saveResult == 0 || !createResult)
                {
                    throw new ConflictException(_responseMessage.AddFailure);
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                _logger.LogError(exeption.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> UpdateNoteAsync(NotesEditDTO notesEditDTO)
        {
            var existedNote = await _unitOfWork.NoteRepository.GetAsync(x => x.Id == notesEditDTO.Id &&x.IsDelete==false);
            if (existedNote == null)
            {
                throw new NotFoundException(_responseMessage.NotFound);
            }
            var note = _mapper.Map<Notes>(notesEditDTO);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updateResult = await _unitOfWork.NoteRepository.UpdateAsync(note);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                {
                    throw new ConflictException(_responseMessage.UpdateFailure);
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                _logger.LogError(exeption.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> SoftDeleteNoteAsync(int noteId)
        {
            var existedNote = await _unitOfWork.NoteRepository.GetAsync(x=>x.Id==noteId&& x.IsDelete==false);
            if (existedNote == null)
            {
                throw new NotFoundException(_responseMessage.NotFound);
            }
            existedNote.IsDelete = true;
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updateResult = await _unitOfWork.NoteRepository.UpdateAsync(existedNote);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                {
                    throw new ConflictException();
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                _logger.LogError(exeption.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<int> GetEnrollCourseIdByCourseIdAndUserId(int courseId, int studentId)
        {
            var enrollCourse = await _unitOfWork.EnrollCourseRepository.GetAsync(x => x.CourseId == courseId && x.StudentId == studentId && x.IsDelete == false);
            if (enrollCourse == null)
            {
                throw new NotFoundException(_responseMessage.NotFound);
            }
            return enrollCourse.Id;
        }

    }
}

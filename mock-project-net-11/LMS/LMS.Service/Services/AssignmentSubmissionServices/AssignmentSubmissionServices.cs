using AutoMapper;
using LMS.Model.Request.AssignmentSubmissionsDTOs;
using LMS.Model.Request.CommonDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.FileStorageServices;
using LMS.Service.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LMS.Service.Services.AssignmentSubmissionServices
{
    public class AssignmentSubmissionServices : IAssignmentSubmissionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AssignmentSubmissionServices> _logger;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public AssignmentSubmissionServices(IUnitOfWork unitOfWork, ILogger<AssignmentSubmissionServices> logger,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }
        
        public async Task<bool> CheckAssignmentSubmissionCompleted(CheckStatusStudyDTO checkStatusStudyDTO)
        {
            try
            {
                var result = await _unitOfWork.AssignmentSubmissionRepository.ExistsAsync(ass=> 
                    ass.UserId== checkStatusStudyDTO.UserID && ass.AssignmentId== checkStatusStudyDTO.TypeCheckID);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Check Assignment Submission Completed", nameof(CheckAssignmentSubmissionCompleted));
                throw;
            }
        }
        
        public async Task<bool> CreateAssignmentSubmission(AssignmentSubmissionsCreateDTO assignmentSubmissionsCreateDTO)
        {         
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var assignmentSubmission = _mapper.Map<AssignmentSubmissions>(assignmentSubmissionsCreateDTO);
                assignmentSubmission.PercentCompleted = 100;
                assignmentSubmission.CreatedAt = assignmentSubmission.UpdatedAt = assignmentSubmission.SubmitDate = DateTime.Now;
                assignmentSubmission.FileUrl = assignmentSubmissionsCreateDTO.FileName;
                var result = await _unitOfWork.AssignmentSubmissionRepository.AddAsync(assignmentSubmission);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot"}" + "\\" + assignmentSubmissionsCreateDTO.FileName;
                await _fileStorageService.DeleteFileAsync(fileName);
                _logger.LogError(ex, "{0} {1}", "Create Assignment Submission failed in service", nameof(CreateAssignmentSubmission));
                throw;
            }
        }
    }
}

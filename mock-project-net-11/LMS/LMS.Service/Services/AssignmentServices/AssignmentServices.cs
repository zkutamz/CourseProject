using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.AssignmentDTOs;
using LMS.Model.Response.AssignmentDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using LMS.Service.Services.SectionServices;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;

namespace LMS.Service.Services.AssignmentServices
{
    public class AssignmentServices : IAssignmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AssignmentServices> _logger;
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;
        private readonly ResponseMessageOptions _responseMessage;

        public AssignmentServices(
            IUnitOfWork unitOfWork, 
            ILogger<AssignmentServices> logger, 
            IMapper mapper,
            ISectionService sectionService,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _sectionService = sectionService;
            _responseMessage = responseMessage.Value;
        }

        public async Task<AssignmentDTO> CreateAssignmentAsync(AssignmentCreateDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var assignment = _mapper.Map<Assignment>(request);



                var result = await _unitOfWork.AssignmentRepository.AddAsync(assignment);

                var updateSectionTotalTimeResult = await _sectionService.UpdateSectionTotalTimeAsync(assignment.SectionId, assignment.TotalTime);

                if (result)
                {
                    await _unitOfWork.SaveAsync();

                    if (request.AssignmentUrls.Count > 0)
                    {
                        foreach (var attachmentUrl in request.AssignmentUrls)
                        {
                            var attachment = new Attachment
                            {
                                AttachmentUrl = attachmentUrl,
                                AssignmentId = assignment.Id
                            };
                            var attachmentAddedResult = await _unitOfWork.AttachmentRepository.AddAsync(attachment);

                            if(!attachmentAddedResult)
                            {
                                throw new BadRequestException(_responseMessage.AddFailure);
                            }

                            await _unitOfWork.SaveAsync();
                        }
                    }

                    await transaction.CommitAsync();
                }
                else
                {
                    throw new BadRequestException(_responseMessage.AddFailure);
                }

                var assignmentDTO = _mapper.Map<AssignmentDTO>(assignment);

                if (assignmentDTO is null)
                    throw new BadRequestException();

                return assignmentDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateAssignmentAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<bool> UpdateAssignmentAsync(int assignmentId, AssignmentEditDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (assignmentId != request.Id)
                    throw new BadRequestException();

                var assignment = _mapper.Map<Assignment>(request);

                var result = await _unitOfWork.AssignmentRepository.UpdateAsync(assignment);

                if (result is false)
                    throw new BadRequestException();

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(UpdateAssignmentAsync));
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<AssignmentDetailDTO> GetAssignmentDetailAsync(int assignmentId)
        {
            try
            {
                var assignmentDetail = await _unitOfWork.AssignmentRepository.GetAssignmentDetailAsync(assignmentId);
                if (assignmentDetail is null) throw new NotFoundException("Not found");

                var assignmentDetailDTO = _mapper.Map<AssignmentDetailDTO>(assignmentDetail);
                return assignmentDetailDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(UpdateAssignmentAsync));
                throw;
            }
        }
        public async Task<bool> DeleteAssignmentAsync(int assignmentId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (assignmentId <= 0)
                    throw new BadRequestException();

                var assignment = await _unitOfWork.AssignmentRepository.GetAsync(s => s.Id == assignmentId);

                if (assignment is null)
                    throw new NotFoundException();

                assignment.IsDelete = true;

                var result = await _unitOfWork.AssignmentRepository.UpdateAsync(assignment);

                if (result is false)
                    throw new BadRequestException();

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(DeleteAssignmentAsync));
                await transaction.RollbackAsync();
                throw;
            }

        }
    }
}

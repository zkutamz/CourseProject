using LMS.Model.Request.AttachmentDTOs;
using LMS.Model.Response.AttachmentDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;

namespace LMS.Service.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentService
    {
        private readonly ILogger<AttachmentService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AttachmentService(IUnitOfWork unitOfWork, ILogger<AttachmentService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<AttachmentDTO> CreateAttachmentAsync(AttachmentCreateDTO request)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var attachment = _mapper.Map<AttachmentCreateDTO, Attachment>(request);
                await _unitOfWork.AttachmentRepository.AddAsync(attachment);
                await _unitOfWork.SaveAsync();
                if (!_unitOfWork.CheckAlreadyTransaction())
                {
                    await transaction.CommitAsync();
                }
                return _mapper.Map<Attachment, AttachmentDTO>(attachment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateAttachmentAsync));
                await transaction.RollbackAsync();
                await transaction.DisposeAsync();
                throw;
            }
        }
    }
}

using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.AnswerDTOs;
using LMS.Model.Response.AnswerDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.AnswerServices
{
    public class AnswerServices : IAnswerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AnswerServices> _logger;
        private readonly IMapper _mapper;

        public AnswerServices(IUnitOfWork unitOfWork, ILogger<AnswerServices> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<AnswerDTO>> CreateAnswersAsync(List<AnswerCreateDTO> request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var answer = _mapper.Map<List<Answer>>(request);
                await _unitOfWork.AnswerRepository.AddRangeAsync(answer);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                var answerDTO = _mapper.Map<List<AnswerDTO>>(answer);
                if (answerDTO is null)
                    throw new BadRequestException();

                return answerDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(CreateAnswersAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

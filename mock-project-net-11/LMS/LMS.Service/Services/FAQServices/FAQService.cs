using AutoMapper;
using LMS.Model.Request.FAQDTOs;
using LMS.Model.Response.FAQs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Services.FAQServices
{
    public class FAQService : IFAQService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<FAQService> logger;
        private readonly IMapper mapper;

        public FAQService(IUnitOfWork unitOfWork,
            ILogger<FAQService> logger,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<bool> CreateFAQAsync(FAQCreateDTO fAQ)
        {
            using var transaction = await unitOfWork.BeginTransactionAsync();
            try
            {
                var createFAQ = mapper.Map<FAQ>(fAQ);
                createFAQ.CreatedAt = DateTime.Now;
                createFAQ.UpdatedAt = DateTime.Now;
                createFAQ.IsDelete = false;
                var result = await unitOfWork.FAQRepository.AddAsync(createFAQ);
                if (result)
                {
                    await unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    logger.LogInformation("Create FAQ Success");
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                logger.LogError(ex, "{0} {1}", "Create FAQ failed in service", nameof(CreateFAQAsync));
                throw;
            }
        }

        public async Task<FAQDetailDTO> GetDetailFAQById(int id)
        {
            try
            {
                var fAQ = mapper.Map<FAQDetailDTO>(await unitOfWork.FAQRepository.GetFAQById(id));
                if (fAQ == null)
                    return new FAQDetailDTO();
                //TODO throw new notFoundException 
                return fAQ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginatedList<FAQDTO>> GetFAQAsyncPaging(PagingRequest request)
        {
            try
            {
                request ??= new PagingRequest();
                var fAQs = mapper.Map<PaginatedList<FAQ>, PaginatedList<FAQDTO>>(await unitOfWork.FAQRepository.GetFAQPaging(request));
                return fAQs;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> UpdateFAQAsync(int id, FAQEditDTO fAQ)
        {
            using var transaction = await unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != fAQ.Id) return false;
                var editFAQ = mapper.Map<FAQ>(fAQ);
                editFAQ.UpdatedAt = DateTime.Now;
                await unitOfWork.FAQRepository.UpdateAsync(editFAQ);
                await unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                logger.LogInformation("Update FAQ Success");
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                logger.LogError(ex, "{0} {1}", "Update FAQ failed in service", nameof(UpdateFAQAsync));
                throw;
            }
        }
    }
}

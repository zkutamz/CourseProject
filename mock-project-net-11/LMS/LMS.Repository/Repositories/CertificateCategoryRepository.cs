using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class CertificateCategoryRepository : Repository<CertificateCategory>, ICertificateCategoryRepository
    {
        public CertificateCategoryRepository(
            LMSApplicationContext context, ILogger<CertificateCategoryRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
        : base(context, logger, responseMessage)
        {
        }
    }
}

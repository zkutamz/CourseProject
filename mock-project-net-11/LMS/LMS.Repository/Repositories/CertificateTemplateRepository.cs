using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class CertificateTemplateRepository : Repository<Template>, ICertificateTemplateRepository
    {
        public CertificateTemplateRepository(
            LMSApplicationContext context,
            ILogger<CertificateTemplateRepository> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            :base(context,logger, responseMessage)
        {

        }
    }
}

using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class BillingAddressRepository : Repository<BillingAddress>, IBillingAddressRepository
    {
        public BillingAddressRepository(LMSApplicationContext context, ILogger<Repository<BillingAddress>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }
    }
}

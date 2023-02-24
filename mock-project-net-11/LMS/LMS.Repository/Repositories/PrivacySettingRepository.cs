using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class PrivacySettingRepository : Repository<PrivacySetting>, IPrivacySettingRepository
    {
        public PrivacySettingRepository(
            LMSApplicationContext context,
            ILogger<Repository<PrivacySetting>> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }


    }
}

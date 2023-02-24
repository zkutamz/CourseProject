using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class NotificationSettingRepository : Repository<NotificationSetting>, INotificationSettingRepository
    {
        public NotificationSettingRepository(LMSApplicationContext context, ILogger<Repository<NotificationSetting>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }
    }
}

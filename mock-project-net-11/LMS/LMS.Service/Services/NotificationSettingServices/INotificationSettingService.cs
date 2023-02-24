using System.Threading.Tasks;
using LMS.Model.Request.NotificationSettingDTOs;

namespace LMS.Service.Services.NotificationSettingServices
{
    public interface INotificationSettingService
    {
        Task<bool> UpdateAsync(int userId, NotificationSettingEditDTO request);
    }
}

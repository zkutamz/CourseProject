using LMS.Model.Request.PrivacySettingDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.PrivacySettingServices
{
    public interface IPrivacySettingService
    {
        Task<bool> UpdateAsync(int userId, PrivacySettingEditDTO request);
    }
}

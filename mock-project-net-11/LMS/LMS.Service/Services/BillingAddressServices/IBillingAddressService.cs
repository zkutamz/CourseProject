using LMS.Model.Request.BillingAddressDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.BillingAddressServices
{
    public interface IBillingAddressService
    {
        Task<bool> UpdateAsync(int userId, BillingAddressEditDTO request);
    }
}

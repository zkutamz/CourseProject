using System.Threading.Tasks;

namespace LMS.Service.Extensions
{
    public interface IUserAccessor
    {
        Task<int> GetUserId();
    }
}

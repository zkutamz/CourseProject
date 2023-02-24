using System.Threading.Tasks;

namespace LMS.Service.Services.EmailServices
{
    public interface IEmailService
    {
        Task SenderEmailAsync(string to, string subject, string html);
        Task Execute(string apiKey, string to, string subject, string html);
    }
}

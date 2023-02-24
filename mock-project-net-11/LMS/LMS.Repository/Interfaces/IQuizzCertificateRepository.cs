using LMS.Repository.Entities;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IQuizzCertificateRepository : IRepository<QuizzCertificate>
    {
        Task<Certificate> GetCertificateByQuizIdAsync(int quizId);

    }
   
}

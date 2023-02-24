using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class QuizzCertificateRepository : Repository<QuizzCertificate>, IQuizzCertificateRepository
    {
        public QuizzCertificateRepository(LMSApplicationContext context, ILogger<QuizzCertificateRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
         : base(context, logger, responseMessage)
        {

        }

        public async Task<Certificate> GetCertificateByQuizIdAsync(int quizId)
        {
            var certificate = await (from qc in Context.QuizzCertificates
                                     join c in Context.Certificates
                                     on qc.CertificateId equals c.Id
                                     where qc.QuizzId == quizId
                                     select c).FirstOrDefaultAsync();
            return certificate;
        }
    }
}

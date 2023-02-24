using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(LMSApplicationContext context, ILogger<AnswerRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
        : base(context, logger, responseMessage)
        {
        }
    }
}

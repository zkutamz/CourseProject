using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class LessonCompletionRepository : Repository<LessonCompletion>, ILessonCompletionRepository
    {
        public LessonCompletionRepository(LMSApplicationContext context, ILogger<LessonCompletionRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }
    }
}

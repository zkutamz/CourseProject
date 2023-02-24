using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class QuizSectionRepository : Repository<QuizSection>, IQuizSectionRepository
    {
        public QuizSectionRepository(LMSApplicationContext context, ILogger<QuizSectionRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }
        public async Task<int> GetSectionId(int quizId)
        {
            var quizSection = await Context.QuizSections.Where(x => x.QuizId == quizId).FirstOrDefaultAsync();
            return quizSection.SectionId;
        }
    }
}

using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        public QuizRepository(LMSApplicationContext context, ILogger<QuizRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }

        public async Task<Quiz> GetQuizDetailAsync(int quizId)
        {
            IQueryable<Quiz> query = Context.Quizzes;
            try
            {
                query = Context.Quizzes.Where(a => a.Id == quizId).Where(a => !a.IsDelete).Include(a => a.QuizQuestions);
                return await query.SingleOrDefaultAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetQuizDetailAsync));
                throw;
            }
        }
    }
}

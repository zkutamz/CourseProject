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
    public class QuizQuestionRepository : Repository<QuizQuestion>, IQuizQuestionRepository
    {
        public QuizQuestionRepository(LMSApplicationContext context, ILogger<QuizQuestionRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }

        public async Task<QuizQuestion> GetQuizQuestionDetailAsync(int quizQuestionId)
        {
            IQueryable<QuizQuestion> query = Context.QuizQuestions;
            try
            {
                query = Context.QuizQuestions.AsNoTracking().Where(a => a.Id == quizQuestionId).Where(a => !a.IsDelete).Include(a => a.Quiz).Include(a => a.Answers);
                return await query.SingleOrDefaultAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetQuizQuestionDetailAsync));
                throw;
            }
        }
    }
}

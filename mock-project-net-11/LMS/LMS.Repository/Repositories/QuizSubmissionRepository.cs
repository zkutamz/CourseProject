using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class QuizSubmissionRepository : Repository<QuizSubmission>, IQuizSubmissionRepository
    {
        public QuizSubmissionRepository(LMSApplicationContext context, ILogger<QuizSubmissionRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }
        public async Task<List<QuizSubmission>> GetAllQuizSubmission(int userID, int quizID)
        {
            try
            {
                var quizSubmissions = await Context.QuizSubmissions
                                   .AsNoTracking()
                                   .Where(qs => qs.UserId == userID && qs.QuizId == quizID && qs.IsDelete==false)
                                   .Include(qs => qs.Answers).ThenInclude(a => a.QuizQuestion)
                                   .OrderByDescending(qs => qs.SubmitDate)
                                   .ToListAsync();
                return quizSubmissions;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All Quiz Submission failed", nameof(GetAllQuizSubmission));
                throw;
            }
        }

        public async Task<QuizSubmission> GetQuizSubmissionByID(int quizSubmissionID)
        {
            try
            {
                var quizSubmission = await Context.QuizSubmissions
                                   .AsNoTracking()
                                   .Where(qs => qs.Id == quizSubmissionID && qs.IsDelete == false)
                                   .Include(qs => qs.Answers).ThenInclude(a => a.QuizQuestion)
                                   .FirstOrDefaultAsync();
                return quizSubmission;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get Quiz Submission By ID failed", nameof(GetQuizSubmissionByID));
                throw;
            }
        }
    }
}

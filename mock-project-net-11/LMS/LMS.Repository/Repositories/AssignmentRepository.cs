using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(LMSApplicationContext context, ILogger<AssignmentRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }

        public async Task<Assignment> GetAssignmentDetailAsync(int assignmentId)
        {
            IQueryable<Assignment> query = Context.Assignments;
            try
            {
                query = Context.Assignments
                    .Where(a => a.Id == assignmentId)
                    .Where(a => !a.IsDelete)
                    .Include(a => a.Section)
                    .Include(a => a.Attachments)
                    .Include(a => a.AssignmentSubmissions);
                return await query.SingleOrDefaultAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", ResponseMessage.ErrorOccurred, nameof(GetAssignmentDetailAsync));
                throw;
            }
        }
    }
}

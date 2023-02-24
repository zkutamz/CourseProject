using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        public TemplateRepository(LMSApplicationContext context, ILogger<TemplateRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {

        }
        public async Task<Template> GetTemplateBaseOnStatus(bool status)
        {
            var template = await Context.Templates.Where(x => x.IsTemplateForCourse == status).FirstOrDefaultAsync();
            return template;
        }
    }
}

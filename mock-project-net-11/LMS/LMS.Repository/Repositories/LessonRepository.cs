using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository.Repositories
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        private readonly DbSet<Lesson> _db;
        public LessonRepository(LMSApplicationContext context, ILogger<LessonRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
            _db = Context.Lessons;
        }
        public async Task<PaginatedList<Lesson>> GetLessonBySectionId(int sectionId, PagingRequest request)
        {
            //var lessons = from sec in Context.Sections
            //              join les in Context.Lessons
            //              on sec.Id equals les.SectionId
            //              where les.SectionId == sectionId
            //              select les;
            var lessons = Context.Lessons
                .Include(x => x.Attachments)
                .Where(x => x.SectionId == sectionId)
                .AsNoTracking();
            return await PaginatedList<Lesson>.ToPaginatedListAsync(lessons, request.PageNumber, request.PageSize);
        }
    }
}

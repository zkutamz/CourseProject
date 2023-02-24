using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(
            LMSApplicationContext context,
            ILogger<SectionRepository> logger, 
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }

        public async Task<List<Section>> GetSectionsForCourseContentAsync(int courseId)
        {
            try
            {
                var sections = await Context.Sections
                    .Include(s => s.Course).ThenInclude(c => c.EnrollCourses)
                    .Include(s => s.Lessons)
                    .ThenInclude(l => l.LessonCompletions)
                    .Include(s => s.Assignments)
                    .ThenInclude(a => a.AssignmentSubmissions)
                    .Include(s => s.Assignments).ThenInclude(a => a.Attachments)
                    .Include(s => s.QuizSections)
                    .ThenInclude(qs => qs.Quiz)
                    .ThenInclude(q => q.QuizSubmissions)
                    .Where(s => s.CourseId == courseId)
                    .AsNoTracking()
                    .OrderBy(s => s.Position)
                    .ToListAsync();
                return sections;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetSectionsForCourseContentAsync));
                throw;
            }
        }

        public async Task<Section> GetASectionForCourseAsync(int courseId, int sectionId)
        {
            try
            {
                return await Context.Sections
                    .Include(s => s.Course).ThenInclude(c => c.EnrollCourses)
                    .Include(s => s.Lessons)
                    .ThenInclude(l => l.LessonCompletions)
                    .Include(s => s.Assignments)
                    .ThenInclude(a => a.AssignmentSubmissions)
                    .Include(s => s.QuizSections)
                    .ThenInclude(qs => qs.Quiz)
                    .ThenInclude(q => q.QuizSubmissions)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(s => s.CourseId == courseId &&
                                               s.Id == sectionId &&
                                               s.IsDelete == false);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", ResponseMessage.ErrorOccurred, nameof(GetSectionsForCourseContentAsync));
                throw;
            }
        }
    }
}

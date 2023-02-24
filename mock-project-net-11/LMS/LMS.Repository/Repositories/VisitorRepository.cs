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
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(LMSApplicationContext context, ILogger<Repository<Visitor>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }

        public async Task<int> GetTotalViewOfInstructorByDay(int instructorId, string date)
        {
            try
            {
                int totalView = 0;
                var courses = await Context.Courses
                    .Include(x => x.Visitors)
                    .Where(x => x.InstructorId == instructorId)
                    .ToListAsync();
                foreach (var item in courses)
                {
                    foreach (var visitor in item.Visitors)
                    {
                        if (visitor.CreatedAt.ToString().Contains(date))
                            totalView = totalView + 1;
                    }
                }
                return totalView;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetTotalViewOfInstructorByDay));
                throw;
            }
        }

        public async Task<Dictionary<int,int>> GetTotalViewOfInstructorWeekly(int instructorId, string date)
        {
            try
            {
                Dictionary<int, int> viewInWeek = new Dictionary<int, int>();   
                DateTime dateTime = DateTime.Parse(date);
                for (int i = 0; i < 7; i++)
                {
                    dateTime = dateTime.AddDays(-i);
                    viewInWeek.Add(i, await GetTotalViewOfInstructorByDay(instructorId, dateTime.ToString()));
                    dateTime = DateTime.Parse(date);
                }

                return viewInWeek;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetTotalViewOfInstructorWeekly));
                throw;
            }

        }
    }
}

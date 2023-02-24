using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class UserSubcriberRepository : Repository<UserSubcriber>, IUserSubcriberRepository
    {
        public UserSubcriberRepository(
            LMSApplicationContext context,
            ILogger<Repository<UserSubcriber>> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }

        public async Task<PaginatedList<UserSubcriber>> GetInstrutorsSubsribedAsync(int subscriberId, PagingRequest pagingRequest)
        {
            var query = Context.UserSubcribers
                .Include(us => us.User).ThenInclude(u => u.EnrollCourses)
                .Include(us => us.User).ThenInclude(u => u.Courses)
                .Where(us => us.SubcriberId == subscriberId);

            return await PaginatedList<UserSubcriber>.ToPaginatedListAsync(query, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public async Task<PaginatedList<UserSubcriber>> GetStudentsSubscribedAsync(int userId, PagingRequest pagingRequest)
        {
            var query = Context.UserSubcribers
                .Include(us => us.Subscriber)
                .Where(us => us.UserId == userId);

            return await PaginatedList<UserSubcriber>.ToPaginatedListAsync(query, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public async Task<List<UserSubcriber>> GetTotalNewInstrutorsSubscribing()
        {

            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            //filter: Get all instructor subscribing
            var check = await (from us in Context.UserSubcribers
                               from c in Context.Courses
                               where c.InstructorId == us.SubcriberId
                               select us
                         ).Distinct().ToListAsync();

            var data = await (from us in Context.UserSubcribers
                              where us.CreatedAt >= thirtyDaysAgo
                              select us).ToListAsync();

            //Intersect lấy trùng của 2 list
            return data.Intersect(check).ToList();
        }

        public async Task<List<UserSubcriber>> GetTotalNewStudentSubscribing()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            //filter: Get all instructor subscribing
            var check = await (from us in Context.UserSubcribers
                               from c in Context.Courses
                               where c.InstructorId == us.SubcriberId
                               select us
                         ).Distinct().ToListAsync();

            var data = await (from us in Context.UserSubcribers
                              where
                              us.CreatedAt >= thirtyDaysAgo
                              select us).ToListAsync();

            //Intersect lấy trùng của 2 list >< Except
            return data.Except(check).ToList();
        }

        public async Task<List<UserSubcriber>> GetTotalStudentSubscribing()
        {
            var data = await Context.UserSubcribers.ToListAsync();
            return data;
        }

        public async Task<List<UserSubcriber>> GetTotalInstrutorsSubscribing()
        {
            var data = await Context.UserSubcribers.ToListAsync();
            return data;
        }

    }
}

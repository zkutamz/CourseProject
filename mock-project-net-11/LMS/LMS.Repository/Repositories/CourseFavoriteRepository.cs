using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class CourseFavoriteRepository : Repository<FavoriteCourse>, ICourseFavoriteRepository
    {
        public CourseFavoriteRepository(LMSApplicationContext context, ILogger<CourseFavoriteRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
           : base(context, logger, responseMessage)
        {
        }

        public async Task<PaginatedList<FavoriteCourse>> GetAllFavoriteCourses(int userID, PagingRequest pagingRequest)
        {
            try
            {
                var favorites = Context.FavoriteCourses
                    .Where(fc => fc.UserId == userID)
                    .Include(fc => fc.Course).ThenInclude(c => c.AppUser)
                    .Include(fc => fc.Course).ThenInclude(c => c.Category)
                    .Include(fc => fc.Course).ThenInclude(c => c.EnrollCourses).ThenInclude(ec => ec.Review);

                return await PaginatedList<FavoriteCourse>
                    .ToPaginatedListAsync(
                        favorites,
                        pageNumber: pagingRequest.PageNumber,
                        pageSize: pagingRequest.PageSize);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All Favorite Courses Paging failed", nameof(GetAllFavoriteCourses));
                throw;
            }
        }

        public async Task<List<FavoriteCourse>> GetAllFavoriteCourses(int userID)
        {
            try
            {
                var favoriteCourses = await Context.FavoriteCourses
                                   .AsNoTracking()
                                   .Where(fc => fc.UserId == userID)
                                   .ToListAsync();
                return favoriteCourses;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Get All Favorite Courses failed", nameof(GetAllFavoriteCourses));
                throw;
            }
        }
    }
}

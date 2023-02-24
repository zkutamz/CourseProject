using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface ICourseFavoriteRepository : IRepository<FavoriteCourse>
    {
        /// <summary>
        /// Get All Favorite Courses of user and paging.
        /// </summary>
        /// <param name="userID">int userID</param>
        /// <param name="pagingRequest">PagingRequest</param>
        /// <returns>PaginatedList<FavoriteCourse></returns>
        Task<PaginatedList<FavoriteCourse>> GetAllFavoriteCourses(int userID,PagingRequest pagingRequest);
        
        /// <summary>
        /// Get All Favorite Courses of user.
        /// </summary>
        /// <param name="userID">int userID</param>
        /// <returns>List<FavoriteCourse></returns>
        Task<List<FavoriteCourse>> GetAllFavoriteCourses(int userID);
    }
}

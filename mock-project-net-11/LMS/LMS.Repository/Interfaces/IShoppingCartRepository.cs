using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        /// <summary>
        /// get all course in user's shopping cart
        /// </summary>
        /// <param name="userId">list course in shopping cart</param>
        /// <returns></returns>
        List<Course> GetCourseShoppingCart(int userId);
        /// <summary>
        /// Get sum original price of all course in shopping cart
        /// </summary>
        /// <param name="userId">user is login</param>
        /// <returns></returns>
        decimal GetOriginalPriceShoppingCart(int userId);
        /// <summary>
        /// Get sum discount price of all course in shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        decimal GetDiscountPriceShoppingCart(int userId);

        /// <summary>
        /// check user used coupon code or not
        /// </summary>
        /// <param name="userId"> user's id login</param>
        /// <returns>true if used and false if not</returns>
        bool CheckOutUserShoppingCart(int userId);
        /// <summary>
        /// Get course purchased by studentId from ShoppingCart
        /// </summary>
        /// <param name="studentId">Id of student</param>
        /// <param name="pagingRequest">query</param>
        /// <returns>List course of student</returns>
        Task<PaginatedList<ShoppingCart>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest);

    }
}

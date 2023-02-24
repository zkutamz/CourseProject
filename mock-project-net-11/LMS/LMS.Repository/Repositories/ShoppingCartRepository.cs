using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(LMSApplicationContext context, ILogger<Repository<ShoppingCart>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }

        public bool CheckOutUserShoppingCart(int userId)
        {
            var cart = Context.ShoppingCarts
                .Where(s => s.UserId == userId && s.IsPending == true);
            foreach (var cartItem in cart)
            {
                cartItem.IsPending = false;
            }
            Context.ShoppingCarts.UpdateRange(cart);
            return true;
        }

        public async Task<PaginatedList<ShoppingCart>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest)
        {
            var data = Context.ShoppingCarts
                .AsNoTracking()
                .AsQueryable()
                .Where(f => f.UserId == studentId && f.IsPending == true)
                .Include(x => x.Course)
                .ThenInclude(x => x.AppUser)
                .Include(y => y.Course).ThenInclude(y => y.Category);


            return await PaginatedList<ShoppingCart>.ToPaginatedListAsync(data,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        public List<Course> GetCourseShoppingCart(int userId)
        {
            return Context.ShoppingCarts
                .Where(s => s.UserId == userId && s.IsPending == true)
                .Join(Context.Courses, s => s.CourseId, c => c.Id, (s, c) => c).ToList();
        }

        public decimal GetDiscountPriceShoppingCart(int userId)
        {
            var course = Context.ShoppingCarts
                .Where(s => s.UserId == userId && s.IsPending == true)
                .Join(Context.Courses, s => s.CourseId, c => c.Id, (s, c) => c);
            var discount = Context.CourseDiscounts.Where(d => d.StartDate <= DateTime.Now && d.EndDate >= DateTime.Now && d.IsDelete == false);
            var totalDiscount = course.Join(discount, c => c.Id, d => d.CourseId, (c, d) => new
            {
                CourseId = c.Id,
                CourseDiscount = c.OriginalPrice * d.DiscountAmount
            }).Sum(c => c.CourseDiscount);
            return totalDiscount;
        }

        public decimal GetOriginalPriceShoppingCart(int userId)
        {
            var originalPrice = Context.ShoppingCarts
                .Where(s => s.UserId == userId && s.IsPending == true)
                .Join(Context.Courses, s => s.CourseId, c => c.Id, (s, c) => c).Sum(c => c.OriginalPrice);
            return (decimal)originalPrice;
        }

    }
}

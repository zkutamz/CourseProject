using LMS.Model.Response.ShoppingCartDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.ShoppingCartServices
{
    public interface IShoppingCartService
    {
        Task<ShoppingCartDto> AddCourseToCart(int userId, int courseId);
        Task<ShoppingCartDto> RemoveCourseToCart(int userId, int courseId);
        ShoppingCartDto GetShoppingCart(int userId);
        Task<ShoppingCartDto> ApplyCouponCode(int userId, string couponCode);
        Task<bool> CheckOutShoppingCart(int userId, ShoppingCartDto shoppingCartDto);

    }
}

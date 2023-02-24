using LMS.Model.Constant;
using LMS.Model.Response.ShoppingCartDTOs;
using LMS.Service.Extensions;
using LMS.Service.Services.ShoppingCartServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartDto ShoppingCartDto;
        private readonly IUserAccessor _userAccessor;
        public ShoppingCartController(IShoppingCartService shoppingCartService, IUserAccessor userAccessor)
        {
            _shoppingCartService = shoppingCartService;
            ShoppingCartDto = new ShoppingCartDto();
            _userAccessor = userAccessor;
        }
        /// <summary>
        /// Add course to shopping cart, a course in cart is pending
        /// </summary>
        /// <param name="courseId">course's id use to find course</param>
        /// <returns>list of course that student want to by</returns>
        /// 
        [HttpPost]
        [Route("AddCourseToCart")]
        public async Task<IActionResult> AddCourseToCart(int courseId)
        {
            var userId = await _userAccessor.GetUserId();
            return HandleResult(await _shoppingCartService.AddCourseToCart(userId, courseId), LmsAction.Add);
        }
        /// <summary>
        /// Remove course from cart
        /// </summary>
        /// <param name="courseId">course's id</param>
        /// <returns>Shopping cart information after delete course</returns>
        [HttpPost]
        [Route("RemoveCourseToCart")]
        public async Task<IActionResult> RemoveCourseToCart(int courseId)
        {
            var userId = await _userAccessor.GetUserId();
            return HandleResult(await _shoppingCartService.RemoveCourseToCart(userId, courseId), LmsAction.Delete);
        }
        /// <summary>
        /// Get all course in shopping cart, original price, discount price, and total price need to pay
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ShoppingCart")]
        public async Task<IActionResult> GetShoppingCart()
        {
            var userId = await _userAccessor.GetUserId();
            return HandleResult(_shoppingCartService.GetShoppingCart(userId));
        }
        /// <summary>
        /// Apply coupon code for shopping cart
        /// </summary>
        /// <param name="couponCode">voucher sales off</param>
        /// <returns>user's cart after sales off</returns>
        [HttpPost]
        [Route("ApplyCouponCode")]
        public async Task<IActionResult> ApplyCouponCode(string couponCode)
        {
            var userId = await _userAccessor.GetUserId();
            return HandleResult(await _shoppingCartService.ApplyCouponCode(userId, couponCode));
        }
        /// <summary>
        /// check out shopping cart
        /// </summary>
        /// <returns>create order header and order detail and check all item in shopping cart is active</returns>
        [HttpPost]
        [Route("CheckOutShoppingCart")]
        public async Task<IActionResult> CheckOutShoppingCart()
        {
            var userId = await _userAccessor.GetUserId();
            var shoppingCartDto = _shoppingCartService.GetShoppingCart(userId);
            return HandleResult(await _shoppingCartService.CheckOutShoppingCart(userId, shoppingCartDto));
        }
    }
}
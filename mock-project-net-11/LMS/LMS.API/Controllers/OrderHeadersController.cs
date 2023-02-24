using LMS.Repository.Paging;
using LMS.Service.Services.OrderHeaderServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeadersController : BaseController
    {
        private IOrderHeaderService _orderHeaderService;
        public OrderHeadersController(IOrderHeaderService orderHeaderService)
        {
            _orderHeaderService = orderHeaderService; ;
        }

        /// <summary>
        /// Get orders of an instructor courses
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("{instructorId:int}")]
        public async Task<ActionResult> GetOrdersOfAnInstructorCourses(int instructorId, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(
                await _orderHeaderService.GetAllOrdersOfAnInstructorsCourses(instructorId, pagingRequest));
        }
    }
}

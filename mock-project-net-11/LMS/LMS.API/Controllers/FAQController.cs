using LMS.Model.Constant;
using LMS.Model.Request.FAQDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.FAQServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : BaseController
    {
        private readonly IFAQService fAQService;
        private readonly ILogger<FAQController> logger;

        public FAQController(IFAQService fAQService,
            ILogger<FAQController> logger)
        {
            this.fAQService = fAQService;
            this.logger = logger;
        }
        /// <summary>
        /// API get all FAQ with paging
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetFAQ([FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await fAQService.GetFAQAsyncPaging(pagingRequest));
        }
        /// <summary>
        /// API get detail FAQ
        /// </summary>
        /// <param name="id">Id of FAQ</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDetailFAQById(int id)
        {
            return HandleResult(await fAQService.GetDetailFAQById(id));
        }
        /// <summary>
        /// API create FAQ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostFAQ(FAQCreateDTO request)
        {
            return HandleResult(await fAQService.CreateFAQAsync(request), LmsAction.Add);
        }
        /// <summary>
        /// API update FAQ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutFAQ(int id, FAQEditDTO request)
        {
            return HandleResult(await fAQService.UpdateFAQAsync(id, request), LmsAction.Update);
        }
    }
}

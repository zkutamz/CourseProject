using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.CertificateCategoryDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.CertificateCategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CertificateCategoriesController : BaseController
    {
        private readonly ICertificateCategoryService _certificateCategoryService;
        public CertificateCategoriesController(ICertificateCategoryService cerificateCategoryId)
        {
            _certificateCategoryService = cerificateCategoryId;
        }

        /// <summary>
        /// Get certificate category by id
        /// </summary>
        /// <param name="certificateCategoryId"></param>
        /// <returns>Status code: 200 and certificate category data; Status code:404 and message if not found;</returns>
        [HttpGet("{certificateCategoryId}")]
        public async Task<IActionResult> GetCertificateCategory(int certificateCategoryId)
        {
            var result = await _certificateCategoryService.GetCertificateCategoryById(certificateCategoryId);
            return HandleResult(result, LmsAction.Get);
        }
        /// <summary>
        /// Get list of certificate category
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>Status code: 200 and list of certificate category data if success; Status code:400 and message if not found</returns>
        [HttpGet]
        public async Task<IActionResult> GetCertificateCategories([FromQuery] PagingRequest pagingRequest)
        {
            var result = await _certificateCategoryService.GetCertificateCategories(pagingRequest);
            return HandleResult(result);
        }
        /// <summary>
        /// Create new instance of certificate category
        /// </summary>
        /// <param name="certificateCategoryCreateDto"></param>
        /// <returns>Status code: 200 if success; Status code: 400 if the data input is invalid;
        /// Status code 409 and message if create is conflicted</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCertificateCategories(CertificateCategoryCreateDTO certificateCategoryCreateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _certificateCategoryService.CreateCertificateCategoryAsync(certificateCategoryCreateDto);
                return HandleResult(result);
            }
            throw new BadRequestException();

        }
        /// <summary>
        /// Update existed certificate category
        /// </summary>
        /// <param name="certificateCategoryEditDto"></param>
        /// <returns>Status code: 200 if success; Status code: 400 if the data input is invalid;
        /// Status code 409 and message if  conflicted</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCertificateCategories(CertificateCategoryEditDTO certificateCategoryEditDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _certificateCategoryService.UpdateCertificateCategoryAsync(certificateCategoryEditDto);
                return HandleResult(result);
            }
            throw new BadRequestException();
        }
        /// <summary>
        /// Delete existed certificate category 
        /// </summary>
        /// <param name="certificateCategoryId"></param>
        /// <returns>Status code: 200 if success; Status code 404 if not found; Status code 409 if delete conflic</returns>
        [HttpDelete("certificateCategoryId")]
        public async Task<IActionResult> DeleteCertificateCategories(int certificateCategoryId)
        {
            var result = await _certificateCategoryService.SoftDeleteCertificateCategoryAsync(certificateCategoryId);
            return HandleResult(result);
        }
    }
}

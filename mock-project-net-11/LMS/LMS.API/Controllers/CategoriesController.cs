using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.CategoryDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO request)
        {
            try
            {
                await _categoryService.AddAsync(request);
                return HandleResult(Ok(), LmsAction.Add);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Get category details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await _categoryService.GetAsync(id);
                return HandleResult(model, LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Get all category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _categoryService.GetAllAsync();
                return HandleResult(models, LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Get list category paging
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var models = await _categoryService.GetPagingAsync(pagingRequest);
                return HandleResult(models, LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, CategoryEditDTO request)
        {
            try
            {
                await _categoryService.UpdateAsync(id, request);
                return HandleResult(Ok(), LmsAction.Update);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
                return HandleResult(Ok(), LmsAction.Delete);
            }
            catch (Exception e)
            {
                throw new ConflictException(e.Message);
            }
        }
    }
}

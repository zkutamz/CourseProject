using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Model.Request.CategoryDTOs;
using LMS.Model.Response.CategoryDTOs;
using LMS.Repository.Paging;

namespace LMS.Service.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<bool> AddAsync(CategoryCreateDTO request);
        Task<bool> UpdateAsync(int id, CategoryEditDTO request);
        Task<CategoryDTO> GetAsync(int id);
        Task<PagingResult<CategoryDTO>> GetPagingAsync(PagingRequest pagingRequest);
        Task<List<CategoryDTO>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}

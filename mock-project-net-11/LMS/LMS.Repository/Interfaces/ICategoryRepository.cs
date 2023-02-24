using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Repository.Entities;

namespace LMS.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllCategoryAsync();
    }
}

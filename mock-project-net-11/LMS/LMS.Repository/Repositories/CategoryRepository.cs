using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly LMSApplicationContext _context;
        private readonly ILogger<Repository<Category>> _logger;

        public CategoryRepository(LMSApplicationContext context, ILogger<Repository<Category>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) 
            : base(context, logger, responseMessage)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            try
            {
                var result = await _context.Categories.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                _logger.LogError($"Something went wrong in {nameof(GetAllAsync)}");
                throw;
            }
        }
    }
}

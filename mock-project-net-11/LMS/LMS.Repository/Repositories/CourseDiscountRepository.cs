using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class CourseDiscountRepository : Repository<CourseDiscount>, ICourseDiscountRepository
    {
        public CourseDiscountRepository(LMSApplicationContext context, ILogger<Repository<CourseDiscount>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }
    }
}

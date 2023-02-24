using LMS.Repository.Context;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class InstructorRespository : IInstructorRespository
    {
        private readonly LMSApplicationContext _context;
        private readonly ILogger<InstructorRespository> _logger;
        private readonly IOptionsSnapshot<ResponseMessageOptions> _responseMessage;

        public InstructorRespository(
            LMSApplicationContext context,
            ILogger<InstructorRespository> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
        {
            _context = context;
            _logger = logger;
            _responseMessage = responseMessage;
        }

    }
}

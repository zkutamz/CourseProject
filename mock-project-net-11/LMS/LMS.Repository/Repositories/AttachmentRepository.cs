using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(LMSApplicationContext context, ILogger<Repository<Attachment>> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }
    }
}

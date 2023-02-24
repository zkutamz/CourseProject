using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class ReactRepository : Repository<Reaction>, IReactRepository
    {
        public ReactRepository(LMSApplicationContext context,
            ILogger<Repository<Reaction>> logger, 
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) 
            : base(context, logger, responseMessage)
        {
        }
    }
}

using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Repository.Repositories
{
    public class UserLoginTokenRepository : Repository<UserLoginToken>, IUserLoginTokenRepository
    {
        public UserLoginTokenRepository(LMSApplicationContext context, ILogger<Repository<UserLoginToken>> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {
        }
    }
}

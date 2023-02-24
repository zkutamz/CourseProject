using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class UserCertificateRepsotiry: Repository<UserCertificate>, IUserCertificateReposity
    {
        public UserCertificateRepsotiry(LMSApplicationContext context, ILogger<UserCertificateRepsotiry> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            :base(context, logger, responseMessage)
        {

        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;

namespace LMS.API.Providers
{
    public class EmailConfirmationTokenProviderOptions: DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
            Name = "EmailDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromHours(4);
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LMS.Service.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccessor : IUserAccessor
    {
        #region Attributes

        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion


        #region Methods

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// TODO: Note lai mai hoi lai khang: Ko lay id cua user trong token thay vi cach nay nhi?
        /// </summary>
        /// <returns></returns>
        public Task<int> GetUserId()
        {
            var result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Task.FromResult(result != null ? int.Parse(result) : 0);
        }

        #endregion
    }
}

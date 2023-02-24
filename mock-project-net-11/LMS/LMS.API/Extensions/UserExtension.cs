using LMS.Model.Exceptions;
using System;
using System.Security.Claims;

namespace LMS.API.Extensions
{
    /// <summary>
    /// Extension of User ClaimsPrincipal
    /// </summary>
    public static class UserExtension
    {
        /// <summary>
        /// Get id of current user logged
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            try
            {
                if (principal == null)
                    throw new BadRequestException(nameof(principal));
                var result = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (result != null)
                {
                    return int.Parse(result);
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new UnauthorizedAccessException($"Login failed. {e}");
            }

        }
    }
}

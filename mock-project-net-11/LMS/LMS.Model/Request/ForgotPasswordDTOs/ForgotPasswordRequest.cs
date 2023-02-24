using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.ForgotPasswordDTOs
{
    /// <summary>
    /// Forgot password Email
    /// </summary>
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}

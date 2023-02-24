using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.LoginDTOs
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue(true)]
        public bool Remember { get; set; } = false;
    }
}

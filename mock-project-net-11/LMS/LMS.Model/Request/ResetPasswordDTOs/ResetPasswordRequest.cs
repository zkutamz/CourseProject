using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.ResetPasswordDTOs
{
    public class ResetPasswordRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string TokenReset { get; set; }
    }
}

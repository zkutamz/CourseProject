using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.RegisterDTOs
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

    }
}

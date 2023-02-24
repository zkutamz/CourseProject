using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.HelpDTOs
{
    public class HelpCreateDTO
    {
        [Required]
        public string UserContent { get; set; }
    }
}

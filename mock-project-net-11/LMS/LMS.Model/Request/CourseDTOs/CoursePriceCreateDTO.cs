using LMS.Model.Constant;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.CourseDTOs
{
    public class CoursePriceCreateDTO
    {
        [Required(ErrorMessage = ResponseMessage.AddPriceWithoutCourse)]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal OriginalPrice { get; set; }
        public bool RequiredLogIn { get; set; } = false;
        public bool RequireEnroll { get; set; } = false;
    }
}

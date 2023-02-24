using LMS.Model.Constant;
using System.ComponentModel.DataAnnotations;


namespace LMS.Model.Request.CourseDTOs
{
    public class CourseMediaCreateDTO
    {
        [Required(ErrorMessage = ResponseMessage.AddMediaWithoutCourse)]
        public int Id { get; set; }
        public string IntroOverviewFile { get; set; }
        public string IntroOverviewUrl { get; set; }
        [Required]
        public string ThumbNail { get; set; }
    }
}

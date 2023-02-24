using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.HelpTopicDTOs
{
    public class HelpTopicCreateDTO
    {
        [Required]
        public string Title { get; set; }
        public string IconURL { get; set; }
        public string Description { get; set; }
        [Required]
        public int HelpId { get; set; }
    }
}

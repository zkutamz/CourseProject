using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.SectionDTOs
{
    public class SectionEditDTO : SectionCreateDTO
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public int TotalTime { get; set; }
    }
}
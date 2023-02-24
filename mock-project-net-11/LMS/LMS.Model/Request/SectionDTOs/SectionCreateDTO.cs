using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.SectionDTOs
{
    public class SectionCreateDTO
    {
        #region Properties

        [Required]
        [StringLength(maximumLength: 255, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CourseId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Position { get; set; }

        #endregion
    }
}
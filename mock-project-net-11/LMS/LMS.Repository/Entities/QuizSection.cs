using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Repository.Entities
{
    public class QuizSection
    {
        public int QuizId { get; set; }
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        [Key]
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}

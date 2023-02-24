using LMS.Model.Request.AnswerDTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS.Model.Request.QuizSubmissionDTOs
{
    public class UserAnswersDTO
    {
        [Required]
        public int AppUserId { get; set; }
        [Required]
        public int QuizId { get; set; }
        public List<AnswerOriginCreateDTO> Answers { get; set; }
    }
}

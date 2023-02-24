using System.Collections.Generic;
using LMS.Model.Request.QuizQuestionDTOs;
using Microsoft.AspNetCore.Http;

namespace LMS.Model.Request.QuizDTOs
{
    public class QuizCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public int TotalTime { get; set; }
        public bool IsPublic { get; set; }
        public bool IsExposedQuestion { get; set; }
        public int SectionId { get; set; }
        //public List<QuizQuestionCreateDTO> QuizQuestions { get; set; }
    }
}

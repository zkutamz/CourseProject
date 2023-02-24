using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Repository.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Model.Response.QuizDTOs
{
    public class QuizForSectionDTO : BaseEntity
    {
        #region Properties
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public int TotalTime { get; set; }
        public bool IsPublic { get; set; }
        public bool IsExposedQuestion { get; set; }

        #endregion

        #region Relationship
        public ICollection<QuizQuestionDTO> QuizQuestions { get; set; }
        #endregion
    }
}

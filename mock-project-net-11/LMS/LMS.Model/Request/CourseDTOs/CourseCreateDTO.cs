using LMS.Repository.Enums;
using System.ComponentModel.DataAnnotations;
using LMS.Model.Constant;
using LMS.Model.Request.SectionDTOs;
using System.Collections.Generic;

namespace LMS.Model.Request.CourseDTOs
{

    public class CourseCreateDTO
    {
        #region Properties
        public int? Id { get; set; }
        [Required]
        [MaxLength(220, ErrorMessage = ResponseMessage.TitleMaxLengthInvalid)]
        public string Title { get; set; }
        [Required]
        [MaxLength(220, ErrorMessage = ResponseMessage.ShortDescriptionMaxLengthInvalid)]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Announcement { get; set; }
        [Required]
        public string Requirement { get; set; }
        [Required]
        public string WhatLearn { get; set; }
        public bool Feature { get; set; }
        [Required]
        public int TotalDuration { get; set; }
        [Required]
        public Level Level { get; set; }
        [Required]
        public string AudioLanguage { get; set; }
        [Required]
        public string CloseCaption { get; set; }
        public int CategoryId { get; set; }
        #endregion

        public IList<SectionCreateDTO> Sections { get; set; }
    }
}

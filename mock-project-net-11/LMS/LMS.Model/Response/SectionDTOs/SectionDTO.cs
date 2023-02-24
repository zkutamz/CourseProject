using System;

namespace LMS.Model.Response.SectionDTOs
{
    public class SectionDTO
    {
        #region Properties

        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public int TotalTime { get; set; }
        public int Position { get; set; }

        #endregion
    }
}
using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class stores information about a lesson
    /// </summary>
    public class Lesson : BaseEntity
    {
        #region Properties

        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string EmbeddedCode { get; set; }
        public int TotalTime { get; set; }
        public bool IsPublic { get; set; }
        public int SectionId { get; set; }
#nullable enable
        public int? Position { get; set; }
#nullable disable

        #endregion

        #region Navigational properties

        public List<Notes> Notes { get; set; }
        public List<LessonCompletion> LessonCompletions { get; set; }
        public List<Attachment> Attachments { get; set; }
        public Section Section { get; set; }

        #endregion
    }
}

using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class stores information about a section
    /// </summary>
    public class Section : BaseEntity
    {
        #region Properties

        public string Name { get; set; }
        public bool IsPublic { get; set; } = true;
        public int TotalTime { get; set; }

#nullable enable
        public int? CourseId { get; set; }
        public int? Position { get; set; }
#nullable disable
        #endregion

        #region Navigational properties
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<QuizSection> QuizSections { get; set; }
        public List<SectionCompletion> SectionCompletions { get; set; }
        #endregion
    }
}

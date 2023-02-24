using System;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class store information of Assignment Submitions
    /// </summary>
    public class AssignmentSubmissions : BaseEntity
    {
        #region Properties
        public DateTime SubmitDate { get; set; }
        public string FileUrl { get; set; }
        public string Answer { get; set; }
        public float PercentCompleted { get; set; }
#nullable enable
        public int? UserId { get; set; }
        public int? AssignmentId { get; set; }
#nullable disable

        #endregion

        #region Navigations
        public AppUser User { get; set; }
        public Assignment Assignment { get; set; }
        #endregion
    }
}

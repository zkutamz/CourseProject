using System;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// Entity LearningPeriods
    /// </summary>
    public class LearningPeriods : BaseEntity
    {
        #region Properties
        public DateTime LearningDate { get; set; }
        public float Period { get; set; }
        #endregion

        #region Relation Properties
        public int UserId { get; set; }
        public AppUser User { get; set; } 
        #endregion
    }
}

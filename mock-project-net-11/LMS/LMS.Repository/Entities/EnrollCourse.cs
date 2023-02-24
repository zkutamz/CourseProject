using System;
using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    /// <summary>
    /// EnrollCourse: 1-n: User, 1-n: Course, 1-n: Review, 1-n: Notes
    /// </summary>
    public class EnrollCourse : BaseEntity
    {
        #region Properties
        public decimal CompletedPercent { get; set; }
#nullable enable
        public string? CertificationURL { get; set; }
        public DateTime? CertificationDate { get; set; }
        public string? Note { get; set; }
#nullable disable
        public int Score { get; set; }
        public bool IsCertificate { get; set; }
        public DateTime EnrollDate { get; set; }
        #endregion
        #region Navigational Properties
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public AppUser AppUser { get; set; }
        public Review Review { get; set; }
        public List<Notes> Notes { get; set; }
        #endregion
    }
}

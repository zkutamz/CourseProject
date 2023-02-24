namespace LMS.Repository.Entities
{
    /// <summary>
    /// This class store information of FavoriteCourse
    /// </summary>
    public class FavoriteCourse : BaseEntity
    {
        #region Properties
#nullable enable   
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
#nullable disable
        #endregion


        #region Navigations
        public AppUser User { get; set; }
        public Course Course { get; set; } 
        #endregion

    }
}

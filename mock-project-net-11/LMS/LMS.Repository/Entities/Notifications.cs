namespace LMS.Repository.Entities
{
    public class Notifications : BaseEntity
    {
        #region Properties
        public string Details { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string Header { get; set; }
        public string ImgURL { get; set; }
        #endregion

        #region RelationProperty
        public AppUser User { get; set; } 
        #endregion
    }
}

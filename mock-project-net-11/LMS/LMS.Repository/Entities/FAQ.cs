namespace LMS.Repository.Entities
{
    public class FAQ : BaseEntity
    {
        #region Properties
        public string Question { get; set; }
        public string Answer { get; set; }
        #endregion

        #region Relation Properties
        public int HelpId { get; set; }
        public Help Help { get; set; } 
        #endregion
    }
}

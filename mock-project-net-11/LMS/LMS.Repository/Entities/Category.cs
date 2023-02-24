using System.Collections.Generic;

namespace LMS.Repository.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Icon { get; set; }

#nullable enable
        public int? ParentId { get; set; }
#nullable disable
        public bool IsActive { get; set; }

        #region Navigational Properties

        public List<Course> Courses { get; set; }
        public List<Specializations> Specializations { get; set; }

        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }

        #endregion 
    }
}
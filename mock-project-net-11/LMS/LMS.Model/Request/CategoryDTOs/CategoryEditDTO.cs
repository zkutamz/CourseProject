using System;

namespace LMS.Model.Request.CategoryDTOs
{
    public class CategoryEditDTO
    {
        public int Id { get; set; }
#nullable enable
        public int? ParentId { get; set; }
#nullable disable
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

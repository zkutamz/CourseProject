using System;

namespace LMS.Model.Response.CategoryDTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

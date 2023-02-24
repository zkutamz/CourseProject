namespace LMS.Model.Request.CategoryDTOs
{
    public class CategoryCreateDTO
    {
#nullable enable
        public int? ParentId { get; set; }
#nullable disable
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

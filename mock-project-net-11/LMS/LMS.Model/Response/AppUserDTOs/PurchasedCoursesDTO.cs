using LMS.Model.Response.CategoryDTOs;

namespace LMS.Model.Response.AppUserDTOs
{
    public class PurchasedCoursesDTO
    {
        public int ViewCount { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public CategoryDTO Category { get; set; }
        public int InstructorId { get; set; }
        public int InstructorName { get; set; }
    }
}

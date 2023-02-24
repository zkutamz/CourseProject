using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CategoryDTOs;

namespace LMS.Model.Response.CourseDTOs
{
    public class CourseForFavoriteDTO : CourseBasicDTO
    {
        public bool IsBestSeller { get; set; }
        public AppUserNameDTO AppUser { get; set; }
        public CategoryDTO Category { get; set; }
    }
}

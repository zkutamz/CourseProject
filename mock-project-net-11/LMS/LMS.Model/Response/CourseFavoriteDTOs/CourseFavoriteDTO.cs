using LMS.Model.Response.CourseDTOs;

namespace LMS.Model.Response.CourseFavoriteDTOs
{
    public class CourseFavoriteDTO
    {
        public int Id { get; set; }
        public CourseForFavoriteDTO Course { get; set; }
    }
}

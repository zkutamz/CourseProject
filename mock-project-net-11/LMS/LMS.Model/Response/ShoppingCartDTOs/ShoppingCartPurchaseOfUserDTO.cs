using LMS.Model.Response.CourseDTOs;
using System;

namespace LMS.Model.Response.ShoppingCartDTOs
{
    public class ShoppingCartPurchaseOfUserDTO
    {
        //public PurchasedCoursesOfStudentDTO Course { get; set; }
        public CourseForFavoriteDTO Course { get; set; }
        public DateTime Created { get; set; }
        public DateTime PurchaseDate => Created;
    }
}

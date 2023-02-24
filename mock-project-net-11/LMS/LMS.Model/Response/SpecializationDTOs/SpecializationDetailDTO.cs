using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CategoryDTOs;

namespace LMS.Model.Response.SpecializationDTOs
{
    public class SpecializationDetailDTO:SpecializationDTO
    {
  
        public  CategoryDTO Category { get; set; }
        public  AppUserDTO User { get; set; }

    }
}
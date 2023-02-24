using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.SectionDTOs;

namespace LMS.Model.Response.SectionCompletionDTOs
{
    public class SectionCompletionDetailDTO:SectionCompletionDTO
    {
       public  AppUserDTO User { get; set; }
       public  SectionDTO Section { get; set; }

    }
}
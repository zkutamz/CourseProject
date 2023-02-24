using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.NotesDTOs;
using LMS.Model.Response.ReviewDTOs;
using System.Collections.Generic;

namespace LMS.Model.Response.EnrollCourses
{
    public class EnrollCourseDetailDTO : EnrollCourseDTO
    {
        public CourseDTO Course { get; set; }
        public AppUserDTO AppUser { get; set; }
        public List<ReviewDTO> ReviewsDTO { get; set; }
        public List<NotesDTO> NotesDTO { get; set; }
    }
}

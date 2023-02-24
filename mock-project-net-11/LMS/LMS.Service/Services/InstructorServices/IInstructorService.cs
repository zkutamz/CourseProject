using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.InstructorDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.InstructorServices
{
    public interface IInstructorService
    {
        /// <summary>
        /// Get total user subcribed of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of user subcription</returns>
        Task<int> TotalSubcriptionOfAnInstructorAsync(int instructorId);
        /// <summary>
        /// Get all courses of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of course</returns>
        Task<int> ToTalCoursesOfAnInstructorAsync(int instructorId);
        /// <summary>
        /// Get all student has enrolled couses of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of student</returns>
        Task<int> TotalEnrollStudentsOfAnInstructorAsync(int instructorId);
        /// <summary>
        /// Get all reviews of user to an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of reviews</returns>
        Task<int> TotalCourseReviewOfAnInstructorAsync(int instructorId);
        /// <summary>
        /// Get list popular instructor
        /// </summary>
        /// <returns>List<AppUserDTO></returns>
        Task<List<InstructorPopularDTO>> GetPopularInstructor();
    
    }
}
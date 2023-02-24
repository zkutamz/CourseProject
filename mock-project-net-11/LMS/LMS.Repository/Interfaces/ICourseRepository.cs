using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public partial interface ICourseRepository : IRepository<Course>
    {
        #region

        Task<PaginatedList<Course>> GetAllActiveCourseAsync(int userid, PagingRequest pagingRequest);
        Task<PaginatedList<Course>> GetAllPendingCourse(int userid, PagingRequest pagingRequest);
        Task<PaginatedList<Course>> GetAllDiscountCourse(int userid, PagingRequest pagingRequest);

        /// <summary>
        /// Get a course detail info.
        /// </summary>
        /// <param name="id">Course ID to filter</param>
        /// <returns>A course object</returns>
        Task<Course> GetCourseDetailAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        bool CourseInDiscount(int courseId, DateTime date);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool CourseAuthor(int courseId, int userId);

        /// <summary>
        /// get all student enroll to instructor
        /// </summary>
        /// <param name="instructorId">instructorId</param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PaginatedList<EnrollCourse>> GetTotalStudentEnrollToInstructor(int instructorId, PagingRequest pagingRequest);
        /// <summary>
        ///  Get the total students studied with an instructor's courses
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PaginatedList<EnrollCourse>> GetTotalStudentStudiedToInstructor(int instructorId, PagingRequest pagingRequest);
        Task<PaginatedList<Course>> GetTotalNumberToInstructorCourses(int instructorId, PagingRequest pagingRequest);
        Task<PaginatedList<Course>> GetLatestCoursePerformanceInformation(PagingRequest pagingRequest);
        Task<List<Course>> GetAllCoursesOfAnInstructorWithoutPagingAsync(int instructorId);

        /// <summary>
        /// Add new course to course table in database
        /// </summary>
        /// <param name="course"></param>
        /// <returns>New course Id</returns>
        Task<int> AddCourseAsync(Course course);

        /// <summary>
        /// Check if user have any draft course of the day
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True if user have draft course on today and false if none</returns>
        Task<bool> CheckDraftCourseOfDay(int userId);

        /// <summary>
        /// Get newest draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Course</returns>
        Task<Course> GetNewestDraftCourse(int userId);

        /// <summary>
        /// Get all draft course of specify user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List Courses</returns>
        Task<List<Course>> GetAllDraftCourseOfUser(int userId);

        #endregion

        #region  Student
        /// <summary>
        /// get all Purchased Courses of this student
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PaginatedList<Course>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest);
        Task<PaginatedList<Course>> GetAllCourseByCategoryName(string categoryName, PagingRequest pagingRequest);
        Task<PaginatedList<Course>> GetAllCourseAsync(PagingRequest pagingRequest);
        Task<List<Course>> GetCurrentCourse();
        Task<Course> PrintPurchasedCourses(int enrollId);

        #endregion

        #region Admin
        /// <summary>
        /// Total Purchased All Courses in System
        /// </summary>
        /// <returns></returns>
        Task<PaginatedList<Course>> GetAllPurchasedCoursesOfSystem(PagingRequest pagingRequest);

        /// <summary>
        /// get total new purchased in one month
        /// </summary>
        /// <returns></returns>
        Task<List<Course>> TotalNewPurchasedCoursesIn1Month();

        /// <summary>
        /// search course  by Title, Description
        /// </summary>
        /// <param name="search"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PaginatedList<Course>> SearchCourse(string search, PagingRequest pagingRequest);


        #endregion

        Task<Course> GetCourseOverviewAsync(int courseId);

        #region Study course inprogress

        /// <summary>
        /// Get Total Quiz Of Course
        /// </summary>
        /// <param name="courseId">courseId</param>
        /// <returns>total quiz</returns>
        Task<int> GetTotalQuizOfCourse(int courseId);
        /// <summary>
        /// Get Total Lesson Of Course
        /// </summary>
        /// <param name="courseId">courseId</param>
        /// <returns>total lesson</returns>
        Task<int> GetTotalLessonOfCourse(int courseId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<int> GetTotalAssignmentOfCourse(int courseId);
        /// <summary>
        /// Get Total Assignment Completed Of User
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="courseId">courseId</param>
        /// <returns>total assignment</returns>
        Task<int> GetTotalAssignmentCompletedOfUser(int userID, int courseId);
        /// <summary>
        /// Get Total Lesson Completed Of User
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="courseId">courseId</param>
        /// <returns>total lesson</returns>
        Task<int> GetTotalLessonCompletedOfUser(int userID, int courseId);
        /// <summary>
        /// Get List QuizID Of Course
        /// </summary>
        /// <param name="courseId">courseId</param>
        /// <returns>List<QuizID></returns>
        Task<List<int>> GetListQuizOfCourse(int courseId);

        #endregion

        #region HomeScreen
        /// <summary>
        /// Search course
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List Course</returns>
        Task<List<Course>> SearchCourse(string query);
        /// <summary>
        /// order by descending course by day published
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns> List Course</returns>
        Task<PaginatedList<Course>> GetCoursesOrderByDesByPublishDate(PagingRequest pagingRequest);
        /// <summary>
        /// get the most sold courses in this month
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>List Course</returns>
        Task<PaginatedList<Course>> GetCoursesByMonth(PagingRequest pagingRequest);

        #endregion
        /// <summary>
        /// get the most sold courses
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List Course</returns>
        Task<PaginatedList<Course>> GetTopCourse(int instructorId, PagingRequest pagingRequest);

    }
}

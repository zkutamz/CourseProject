using LMS.Model.Request.CourseDiscountDTOs;
using LMS.Model.Request.CourseDTOs;
using LMS.Model.Request.CoursePromotionDTOs;
using LMS.Model.Request.SearchDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CourseDiscountDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.CourseFavoriteDTOs;
using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.SectionDTOs;
using LMS.Model.Response.ShoppingCartDTOs;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.CourseService
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICourseService
    {
        public Task<PagingResult<InstructorCourseDto>> GetAllActiveCourseOfInstructor(int userId, PagingRequest pageQueryParams);
        public Task<PagingResult<CourseDTO>> GetAllPendingCourseOfInstructor(int userId, PagingRequest pageQueryParams);
        public Task<PagingResult<CourseDiscountDTO>> GetAllDiscountCourseOfInstructor(int userId, PagingRequest pageQueryParams);
        public Task<CourseDTO> GetCourseByIdAsync(int courseId);
        public Task<bool> DisableActiveCourseByIdAsync(int userId, int courseId);
        Task<PagingResult<EnrollCourseDTO>> GetTotalStudentEnrollToInstructor(int courseId, PagingRequest pagingRequest);
        Task<PagingResult<EnrollCourseDTO>> GetTotalStudentStudiedToInstructor(int courseId, PagingRequest pagingRequest);
        Task<PagingResult<CourseDTO>> GetTotalNumberToInstructorCourses(int courseId, PagingRequest pagingRequest);
        Task<PagingResult<CourseDTO>> GetLatestCoursePerformanceInformation(PagingRequest pagingRequest);
        #region CreateNewCourse
        /// <summary>
        /// Check if any course draft of user on a day
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True if have any and false if none</returns>
        Task<bool> CheckDraftCourseOfDay(int userId);
        /// <summary>
        /// Finish creating new course by change course status to pending
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        Task<bool> CreateCourse(int id);
        /// <summary>
        /// Create new course with basic infor
        /// </summary>
        /// <param name="courseCreate"></param>
        /// <returns>New courseId</returns>
        Task<int> CreateCourseBasic(CourseCreateDTO courseCreate);
        /// <summary>
        /// Update media on creating new course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mediaCreate"></param>
        /// <returns>True if success</returns>
        Task<bool> CreateCourseMedia(int id, CourseMediaCreateDTO mediaCreate);
        /// <summary>
        /// Update course price on creating new course  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="priceCreate"></param>
        /// <returns>True if success</returns>
        Task<bool> CreateCoursePrice(int id, CoursePriceCreateDTO priceCreate);
        /// <summary>
        /// Get newest draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>CourseCreateDTO</returns>
        Task<CourseCreateDTO> GetNewestDraftCourse(int userId);
        #endregion

        /// <summary>
        /// Get all draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List draft course of user</returns>
        Task<List<CourseDTO>> GetAllDraftCourseOfUser(int userId);

        #region FavoriteCourse

        /// <summary>
        /// Get all favorite course of user by userID and paging.
        /// </summary>
        /// <param name="userID">int userID</param>
        /// <param name="pagingRequest">PagingRequest</param>
        /// <returns>A paged list of course favorite dto objects</returns>
        Task<PagingResult<CourseFavoriteDTO>> GetAllFavoriteCoursesAsync(PagingRequest pagingRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<bool> CreateFavoriteCourseAsync(int courseId);

        /// <summary>
        /// Soft delete a favorite course from user's favorites
        /// </summary>
        /// <param name="courseId">Course ID to filter</param>
        /// <returns>Success: return true | Fail: return false</returns>
        Task<bool> DeleteFavoriteCourseAsync(int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAllFavoriteCourseAsync();

        #endregion
        Task<PagingResult<ShoppingCartPurchaseOfUserDTO>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest);
        Task<AppUserDTO> GetTeacherByName(string userName);
        Task<PagingResult<CourseDTO>> GetAllCourseAsync(PagingRequest pagingRequest);
        Task<PagingResult<CourseDTO>> GetAllCourseByCategoryName(string userName, PagingRequest pagingRequest);

        /// <summary>
        /// This method get a list of basic sections information for displaying in a course content.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<List<SectionBasicDTO>> GetCourseSections(int courseId);

        /// <summary>
        /// This method get a list of basic sections information with completion checker for displaying in a course content.
        /// </summary>
        /// <param name="courseId">A course Id of type int to filter</param>
        /// <returns>A list of section basic DTO objects</returns>
        Task<List<SectionBasicDTO>> GetCourseSectionsForStudy(int courseId);
        Task<CourseDiscountCreateDTO> CreateCourseDiscountAsync(int userId, CourseDiscountCreateDTO courseDiscountDTO);
        Task<CourseDiscountEditDTO> UpdateCourseDiscountAsync(int userId, int discountId, CourseDiscountEditDTO courseDiscountDTO);
        Task<bool> DisposeCourseDiscountAsync(int userId, int discountId);
        Task<CoursePromotionCreateDTO> CreatePromotionAsync(int userId, CoursePromotionCreateDTO coursePromotionCreateDTO);
        Task<CoursePromotionCreateDTO> UpdateCoursePromotion(int userId, int promotionId, CoursePromotionCreateDTO coursePromotionCreateDTO);
        Task<bool> DeletePromotionAsync(int userId, int promotionId);
        Task<List<CourseDTO>> GetCurrentCourse();
        Task<List<CourseForInstructorAnlyicDTO>> GetTopCourseForAnalyic(int instructorId);

        /// <summary>
        /// Get overview information of a course
        /// </summary>
        /// <param name="courseId">Id of a course to filter</param>
        /// <returns>A course overview DTO</returns>
        Task<CourseOverviewDTO> GetCourseOverviewDTOAsync(int courseId);

        Task<List<CourseDTO>> SearchCourse(SearchRequest query);


        Task<PurchasedCoursesOfStudentDTO> PrintPurchasedCourses(int enrollId);
        /// <summary>
        /// Total Purchased All Courses in System
        /// </summary>
        /// <returns></returns>
        Task<PagingResult<CourseDTO>> GetAllPurchasedCoursesOfSystem(PagingRequest pagingRequest);
        /// <summary>
        /// Get total new purchased courses in one month
        /// </summary>
        /// <returns></returns>
        Task<List<CourseDTO>> GetNewPurchasedCoursesIn1Month();

        /// <summary>
        /// Get Total Item Of Course: quiz + assignment + lesson.
        /// </summary>
        /// <param name="courseId">courseId</param>
        /// <returns>int total</returns>
        Task<int> GetTotalItemOfCourse(int courseId);

        /// <summary>
        ///  Get Total Item completed Course of user: quiz + assignment + lesson.
        /// </summary>
        /// <param name="courseId">courseId</param>
        /// <param name="userID">userID</param>
        /// <returns>int total</returns>
        Task<int> GetTotalItemCompletedOfCourse(int courseId, int userID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PagingResult<CourseDTO>> GetNewestCourses(PagingRequest pagingRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<PagingResult<CourseDTO>> GetFeaturedCoursesInThisMonth(PagingRequest pagingRequest);

        /// <summary>
        /// This method gets total duration of a course
        /// </summary>
        /// <param name="courseId">Course ID to search</param>
        /// <returns>Total duration of type int</returns>
        Task<int> CalculateTotalDurationOfACourseAsync(int courseId);

        Task<PagingResult<CourseTitlePriceDTO>> TopCourseBuy(int instructorId, PagingRequest pagingRequest);

        /// <summary>
        /// Get a course detail dto object
        /// </summary>
        /// <param name="courseId">Course ID to filter</param>
        /// <returns>A course detail dto object</returns>
        Task<CourseDetailDTO> GetCourse(int courseId);

        /// <summary>
        /// This method get a basic section information for displaying in a course content.
        /// </summary>
        /// <param name="courseId">A course Id of type int to filter</param>
        /// <param name="sectionId">A section Id of type int to filter</param>
        /// <returns>A section basic DTO object</returns>
        Task<SectionBasicDTO> GetCourseSectionForStudy(int courseId, int sectionId);
        Task<bool> IsExistsAsync(int courseId);
        Task<bool> DeletePendingCourse(int userId, int courseId);
    }
}

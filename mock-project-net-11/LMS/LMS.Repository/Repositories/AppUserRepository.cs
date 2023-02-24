using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(
            LMSApplicationContext context,
            ILogger<AppUserRepository> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {

        }

        public Task<int> GetTotalCoursePurchaseAsync(int userId)
        {
            try
            {
                return Context.EnrollCourses.CountAsync(x => x.StudentId == userId);
            }
            catch (Exception e)
            {
                Logger.LogError($"{ResponseMessage.ErrorOccurred} in {nameof(GetTotalCoursePurchaseAsync)}!. {e.Message}");
                throw;
            }
        }

        public Task<int> GetTotalReviewsAsync(int userId)
        {
            try
            {
                return Context.Reviews
                    .Include(r => r.EnrollCourse)
                    .CountAsync(r => r.EnrollCourse.StudentId == userId);
            }
            catch (Exception e)
            {
                Logger.LogError($"{ResponseMessage.ErrorOccurred} in {nameof(GetTotalReviewsAsync)}!. {e.Message}");
                throw;
            }
        }

        public Task<int> GetTotalSubscriptionsAsync(int userId)
        {
            try
            {
                return Context.UserSubcribers.CountAsync(x => x.UserId == userId);
            }
            catch (Exception e)
            {
                Logger.LogError($"{ResponseMessage.ErrorOccurred} in {nameof(GetTotalReviewsAsync)}!. {e.Message}");
                throw;
            }
        }

        public Task<int> GetTotalCertificatesAsync(int userId)
        {
            try
            {
                return Context.UserCertificates.CountAsync(x => x.UserId == userId);
            }
            catch (Exception e)
            {
                Logger.LogError($"{ResponseMessage.ErrorOccurred} in {nameof(GetTotalReviewsAsync)}!. {e.Message}");
                throw;
            }
        }

        public async Task<PaginatedList<Course>> GetPurchasedCoursesAsync(int userId, PagingRequest request)
        {
            try
            {
                var query = Context.Courses
                    .Include(x => x.EnrollCourses)
                    .ThenInclude(x => x.AppUser)
                    .Where(x => x.AppUser.Id == userId)
                    .Select(x => new Course()
                    {
                        AppUser = x.AppUser,
                        Title = x.Title,
                        Price = x.Price,
                        Category = x.Category,
                        ViewCount = x.ViewCount,
                        InstructorId = x.InstructorId,
                        CreatedAt = x.EnrollCourses.SingleOrDefault().CreatedAt
                    });
                return await PaginatedList<Course>.ToPaginatedListAsync(query, request.PageNumber, request.PageSize);
            }
            catch (Exception e)
            {
                Logger.LogError($"{ResponseMessage.ErrorOccurred} in {nameof(GetPurchasedCoursesAsync)}!. {e.Message}");
                throw;
            }
        }

        public async Task<PaginatedList<CourseComment>> GetDiscussionsAsync(int userId, PagingRequest pagingRequest)
        {
            try
            {
                var query = Context.CourseComment
                    .Include(x => x.User)
                    .Where(x => x.Id == userId)
                    .Select(x => new CourseComment()
                    {
                        User = x.User,
                        Content = x.Content,
                        CreatedAt = x.CreatedAt,
                        ChildCourseComments = x.ChildCourseComments
                    });

                return await PaginatedList<CourseComment>.ToPaginatedListAsync(query, pagingRequest.PageNumber, pagingRequest.PageSize);
            }
            catch (Exception e)
            {
                Logger.LogError($"{ResponseMessage.ErrorOccurred} in {nameof(GetDiscussionsAsync)}!. {e.Message}");
                throw;
            }
        }

        public Task<int> GetSubscriptionsAsync(int userId)
        {
            throw new NotImplementedException();
        }


        public async Task<AppUser> GetTeachByName(string userName)
        {
            try
            {
                var data = await Context.AppUsers.Where(x => x.UserName.Contains(userName)).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "{ResponseMessage.ErrorOccurred} in ", nameof(GetTeachByName));
                throw;
            }
        }

        /// <summary>
        /// get all instructors Subscribing by student
        /// </summary>
        /// <param name="studentId">student Id</param>
        /// <returns> list instructor subscribing </returns>
        public async Task<int> GetTotalInstrutorsSubscribingByStudent(int studentId)
        {
            //get all instructors Subscribing by student 
            var totalInstructors = (from u in Context.AppUsers
                                    join ec in Context.EnrollCourses on u.Id equals ec.StudentId
                                    join c in Context.Courses on ec.CourseId equals c.Id
                                    where u.Id == studentId
                                    select new { c.InstructorId, u }).Distinct();


            return await totalInstructors.CountAsync();
        }

        public List<AppUser> GetListPopularInstructor()
        {
            try
            {
                List<AppUser> listInstructor = new List<AppUser>();

                //Get list object instructor with instructorId, numberSudentOfInstructor
                var totalStudentEnrolledInstructors = (from user in Context.AppUsers
                                                       join course in Context.Courses
                                                       on user.Id equals course.InstructorId
                                                       select new
                                                       {
                                                           instructorId = user.Id,

                                                           numberStudentOfInstructor = (from c in Context.Courses
                                                                                        join ec in Context.EnrollCourses on c.Id equals ec.CourseId
                                                                                        join u in Context.AppUsers on ec.StudentId equals u.Id
                                                                                        where c.InstructorId == user.Id
                                                                                        select ec).Count()
                                                       }).Distinct();

                //Arrange descending numberStudentOfInstructor
                totalStudentEnrolledInstructors = totalStudentEnrolledInstructors.OrderByDescending(ins => ins.numberStudentOfInstructor);

                //Get instructors 
                var instructorResult = (from instructor in totalStudentEnrolledInstructors
                                        join user in Context.AppUsers
                                        on instructor.instructorId equals user.Id
                                        select new { user });
                //Get list instructor was arraged
                foreach (var item in instructorResult)
                {
                    listInstructor.Add(item.user);
                }
                return listInstructor;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "{ResponseMessage.ErrorOccurred} in ", nameof(GetListPopularInstructor));
                throw;
            }
            
        }

        public async Task<int> GetRoleIdByUserId(int userId)
        {
            try
            {
                var roleId = await Context.UserRoles
                .Where(r => r.UserId == userId)
                .Select(r => r.RoleId).FirstOrDefaultAsync();
                return roleId;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "{ResponseMessage.ErrorOccurred} in ", nameof(GetRoleIdByUserId));
                throw;
            }
        }
    }
}

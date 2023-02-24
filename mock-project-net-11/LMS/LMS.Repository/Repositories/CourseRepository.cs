using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Enums;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly DbSet<Course> _db;

        public CourseRepository(
            LMSApplicationContext context,
            ILogger<Repository<Course>> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
            _db = Context.Courses;
        }

        public async Task<PaginatedList<Course>> GetAllCourseAsync(PagingRequest pagingRequest)
        {
            var data = Context.Courses
                .AsNoTracking()
                .Include(x => x.EnrollCourses)
                .Include(x => x.Category)
                .Include(x => x.AppUser);
            return await PaginatedList<Course>.ToPaginatedListAsync(data,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        public async Task<Course> PrintPurchasedCourses(int enrollId)
        {
            var data = await _db
                .AsNoTracking()
                .Include(x => x.EnrollCourses)
                .Where(f => f.EnrollCourses.Any(x => x.Id == enrollId))
                .Include(x => x.Category)
                .Include(x => x.AppUser).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<Course>> GetAllCoursesOfAnInstructorWithoutPagingAsync(int instructorId)
        {
            try
            {
                return await Context.Courses.Where(c => c.InstructorId == instructorId).ToListAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetAllCoursesOfAnInstructorWithoutPagingAsync));
                throw;
            }
        }

        public async Task<PaginatedList<Course>> GetLatestCoursePerformanceInformation(PagingRequest pagingRequest)
        {
            //get lastest by Course Comment last 
            var courseLatest = from c in Context.Courses
                               join cm in Context.CourseComment on c.Id equals cm.CourseId
                               orderby cm.CreatedAt descending
                               select c;


            return await PaginatedList<Course>.ToPaginatedListAsync(courseLatest,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        /// <summary>
        /// Get top 5 current course being study 
        /// </summary>
        /// <returns>ouput: top 5 course order by createAt desc</returns>
        public async Task<List<Course>> GetCurrentCourse()
        {
            //Get current course being study (top 5)
            var courseCurrent = await Context.Courses
                .OrderByDescending(x => x.CreatedAt).Take(5)
                .ToListAsync();

            return courseCurrent;
        }

        public async Task<PaginatedList<Course>> GetTotalNumberToInstructorCourses(int instructorId, PagingRequest pagingRequest)
        {
            //get total number by instructorId
            var courseTotal = from c in Context.Courses
                              join u in Context.AppUsers on c.InstructorId equals u.Id
                              where u.Id == instructorId
                              select c;

            return await PaginatedList<Course>.ToPaginatedListAsync(courseTotal,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        public async Task<PaginatedList<EnrollCourse>> GetTotalStudentEnrollToInstructor(int instructorId, PagingRequest pagingRequest)
        {
            //get all student enroll to instructor
            //With CompletedPercent = 0 (mới đăng kí chưa học)
            var query =
                from c in Context.Courses
                join ec in Context.EnrollCourses on c.Id equals ec.CourseId
                join u in Context.AppUsers on ec.StudentId equals u.Id
                where c.InstructorId == instructorId & ec.CompletedPercent == 0
                select new { c, ec, u };


            return await PaginatedList<EnrollCourse>.ToPaginatedListAsync(query.Select(x => x.ec),
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        public async Task<PaginatedList<EnrollCourse>> GetTotalStudentStudiedToInstructor(int instructorId, PagingRequest pagingRequest)
        {
            //get all student enroll to instructor
            //With CompletedPercent = 0 (mới đăng kí chưa học)
            var query =
                from c in Context.Courses
                join ec in Context.EnrollCourses on c.Id equals ec.CourseId
                join u in Context.AppUsers on ec.StudentId equals u.Id
                where c.InstructorId == instructorId & ec.CompletedPercent > 0
                select ec;

            return await PaginatedList<EnrollCourse>.ToPaginatedListAsync(query,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }

        public async Task<PaginatedList<Course>> GetAllPurchasedCoursesOfStudent(int studentId, PagingRequest pagingRequest)
        {
            //var query = from ec in Context.EnrollCourses
            //    join u in Context.AppUsers on ec.StudentId equals u.Id
            //    join c in Context.Courses on ec.CourseId equals c.Id
            //    join ct in Context.Categories on c.CategoryId equals ct.Id
            //    where ec.StudentId == studentId
            //    select c;
            var data = Context.Courses
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.EnrollCourses)
                .Where(f => f.EnrollCourses.Any(x => x.StudentId == studentId))
                .Include(x => x.Category)
                .Include(x => x.AppUser);



            return await PaginatedList<Course>.ToPaginatedListAsync(data,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);

        }

        public async Task<PaginatedList<Course>> GetAllPurchasedCoursesOfSystem(PagingRequest pagingRequest)
        {

            try
            {
                var thirtyDaysAgo = DateTime.Now.AddDays(-30);
                var data = Context.Courses
                    .AsNoTracking()
                    .Include(x => x.EnrollCourses)
                    .Include(x => x.Category)
                    .Include(x => x.AppUser)
                    ;
                return await PaginatedList<Course>.ToPaginatedListAsync(data,
                               pagingRequest.PageNumber,
                               pagingRequest.PageSize);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetAllCourseByCategoryName));
                throw;
            }
        }

        public async Task<List<Course>> TotalNewPurchasedCoursesIn1Month()
        {

            var thirtyDaysAgo = DateTime.Now.AddDays(-30);
            var data = await Context.Courses
                .AsNoTracking()
                .Include(x => x.EnrollCourses)
                .Include(x => x.Category)
                .Include(x => x.AppUser)
                .Where(x => x.CreatedAt >= thirtyDaysAgo).ToListAsync();
            return data;
        }

        /// <summary>
        /// get all course in category by category's name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="pagingRequest"></param>
        /// <returns> output: List course by category name</returns>
        public async Task<PaginatedList<Course>> GetAllCourseByCategoryName(string categoryName, PagingRequest pagingRequest)
        {
            try
            {
                var data = Context.Courses.Include(x => x.Category)
                    .Where(x => x.Category.Name == categoryName);
                return await PaginatedList<Course>.ToPaginatedListAsync(data,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetAllCourseByCategoryName));
                throw;
            }
        }

        /// <summary>
        /// Add new course to course table in database
        /// </summary>
        /// <param name="course"></param>
        /// <returns>New course Id</returns>
        public async Task<int> AddCourseAsync(Course course)

        {
            try
            {
                await Context.Courses.AddAsync(course);
                await Context.SaveChangesAsync();
                return course.Id;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(AddCourseAsync));
                throw;
            }
        }

        public async Task<PaginatedList<Course>> GetAllActiveCourseAsync(int userid, PagingRequest pagingRequest)

        {
            var courses = _db.Where(c => c.InstructorId == userid && c.CourseStatus == Enums.CourseStatus.Active)
                .Include(c => c.Category)
                .Include(c => c.OrderDetails)
                .Include(c => c.Sections);
            return await PaginatedList<Course>.ToPaginatedListAsync(courses, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public async Task<PaginatedList<Course>> GetAllPendingCourse(int userid, PagingRequest pagingRequest)

        {
            var courses = _db.Where(c => c.InstructorId == userid && c.CourseStatus == Enums.CourseStatus.Pending).Include(c => c.Category);
            return await PaginatedList<Course>.ToPaginatedListAsync(courses, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public async Task<PaginatedList<Course>> GetAllDiscountCourse(int userid, PagingRequest pagingRequest)

        {
            var courses = _db.Where(c => c.InstructorId == userid)
                .Include(c => c.CourseDiscounts);
            return await PaginatedList<Course>.ToPaginatedListAsync(courses, pagingRequest.PageNumber, pagingRequest.PageSize);
        }

        public async Task<Course> GetCourseDetailAsync(int id)
        {
            try
            {
                var course = _db
                    .Include(c => c.EnrollCourses).ThenInclude(c => c.Review)
                    .Include(c => c.FavoriteCourses)
                    .Include(c => c.AppUser).ThenInclude(a => a.UserVoters)
                    .FirstOrDefaultAsync(c => c.Id == id);
                return await course;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", ResponseMessage.ErrorOccurred, nameof(GetCourseDetailAsync));
                throw;
            }
        }

        public bool CourseInDiscount(int courseId, DateTime date)


        {
            return _db.Where(c => c.Id == courseId)
                .Join(Context.CourseDiscounts, c => c.Id, cd => cd.CourseId, (c, cd) => cd)
                .Any(c => c.StartDate <= date && c.EndDate >= date);
        }
        public bool CourseAuthor(int courseId, int userId)


        {
            var course = _db.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
                return false;
            if (course.InstructorId == userId) return true;
            return false;
        }
        public async Task<Course> GetCourseOverviewAsync(int courseId)
        {
            try
            {
                return await Context.Courses
                    .Include(c => c.EnrollCourses).ThenInclude(ec => ec.AppUser)
                    .Include(c => c.EnrollCourses).ThenInclude(ec => ec.Review)
                    .Include(c => c.Sections)
                    .SingleOrDefaultAsync(c => c.Id == courseId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> GetTotalQuizOfCourse(int courseId)
        {
            try
            {
                var queryTotalQuiz = (from c in Context.Courses
                                      join s in Context.Sections on c.Id equals s.CourseId
                                      join qs in Context.QuizSections on s.Id equals qs.SectionId
                                      join q in Context.Quizzes on qs.QuizId equals q.Id
                                      where c.Id == courseId
                                      select q);
                return await queryTotalQuiz.CountAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> GetTotalLessonOfCourse(int courseId)
        {
            try
            {
                var queryTotalLesson = (from c in Context.Courses
                                        join s in Context.Sections on c.Id equals s.CourseId
                                        join l in Context.Lessons on s.Id equals l.SectionId
                                        where c.Id == courseId
                                        select l);
                return await queryTotalLesson.CountAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> GetTotalAssignmentOfCourse(int courseId)
        {
            try
            {
                var queryTotalAssignment = (from c in Context.Courses
                                            join s in Context.Sections on c.Id equals s.CourseId
                                            join a in Context.Assignments on s.Id equals a.SectionId
                                            where c.Id == courseId
                                            select a);
                return await queryTotalAssignment.CountAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> GetTotalAssignmentCompletedOfUser(int userID, int courseId)
        {
            try
            {
                var queryTotalAssignmentCompleted = (from c in Context.Courses
                                                     join s in Context.Sections on c.Id equals s.CourseId
                                                     join a in Context.Assignments on s.Id equals a.SectionId
                                                     join ac in Context.AssignmentSubmissions on a.Id equals ac.AssignmentId
                                                     where c.Id == courseId && ac.UserId == userID
                                                     select c);
                return await queryTotalAssignmentCompleted.CountAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> GetTotalLessonCompletedOfUser(int userID, int courseId)
        {
            try
            {
                var queryTotalLessonCompleted = (from c in Context.Courses
                                                 join s in Context.Sections on c.Id equals s.CourseId
                                                 join l in Context.Lessons on s.Id equals l.SectionId
                                                 join lc in Context.LessonCompletion on l.Id equals lc.LessonId
                                                 where c.Id == courseId && lc.UserId == userID
                                                 select c);
                return await queryTotalLessonCompleted.CountAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<List<int>> GetListQuizOfCourse(int courseId)
        {
            try
            {
                var quizIds = await (from c in Context.Courses
                                     join s in Context.Sections on c.Id equals s.CourseId
                                     join qs in Context.QuizSections on s.Id equals qs.SectionId
                                     join q in Context.Quizzes on qs.SectionId equals q.Id
                                     where c.Id == courseId
                                     select q.Id).ToListAsync();
                return quizIds;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PaginatedList<Course>> GetCoursesOrderByDesByPublishDate(PagingRequest pagingRequest)
        {
            var courses = Context.Courses
                .Include(x => x.AppUser)
                .Include(x => x.Category)
                .OrderByDescending(course => course.PublishedDate)
                .AsNoTracking();

            return await PaginatedList<Course>
                .ToPaginatedListAsync(courses,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
        }

        /// <summary>
        /// Get course most buy in this month
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>List course</returns>
        public async Task<PaginatedList<Course>> GetCoursesByMonth(PagingRequest pagingRequest)

        {
            var thisMonth = DateTime.Now.Month;
            var thisYear = DateTime.Now.Year;
            var orderDetailInMonth = Context.OrderDetails
                .Where(o => o.CreatedAt.Month == thisMonth && o.CreatedAt.Year == thisYear)
                .GroupBy(x => x.CourseId).Select(g => new { g.Key, Count = g.Count() });
            var courses = Context.Courses.Join(orderDetailInMonth, c => c.Id, o => o.Key,
                (c, o) => new { c, o }).OrderByDescending(x => x.o.Count).Select(x => x.c);
            var tableResult = courses.AsNoTracking()
                .Include(x => x.AppUser)
                .Include(x => x.Category).AsQueryable();
            return await PaginatedList<Course>.ToPaginatedListAsync(tableResult,
                pagingRequest.PageNumber, pagingRequest.PageSize);

        }

        /// <summary>
        /// Check if user have any draft course of the day
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if user have draft course on today and false if none</returns>
        public async Task<bool> CheckDraftCourseOfDay(int userId)
        {
            try
            {

                return await Context.Courses.AnyAsync(c => c.AppUser.Id == userId && c.CreatedAt.Date == DateTime.Now.Date);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CheckDraftCourseOfDay));
                throw;
            }
        }

        /// <summary>
        /// Get newest draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Course</returns>
        public async Task<Course> GetNewestDraftCourse(int userId)
        {
            try
            {
                return await Context.Courses.Include(c => c.Sections).ThenInclude(s => s.Lessons)
                    .Include(c => c.Sections).ThenInclude(s => s.QuizSections).ThenInclude(q => q.Quiz)
                    .Include(c => c.Sections).ThenInclude(s => s.Assignments)
                    .OrderByDescending(c => c.CreatedAt)
                    .FirstOrDefaultAsync(c => c.AppUser.Id == userId && c.CreatedAt.Date == DateTime.Now.Date && c.CourseStatus == CourseStatus.Draft);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetNewestDraftCourse));
                throw;
            }
        }

        /// <summary>
        /// Get all draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List Course</returns>
        public async Task<List<Course>> GetAllDraftCourseOfUser(int userId)
        {
            try
            {
                return await Context.Courses.Where(c => c.AppUser.Id == userId && c.CourseStatus == CourseStatus.Draft).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetAllDraftCourseOfUser));
                throw;
            }
        }

        /// <summary>
        /// Search course and paging
        /// </summary>
        /// <param name="search"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List course</returns>
        public async Task<PaginatedList<Course>> SearchCourse(string search, PagingRequest pagingRequest)
        {
            var query = from c in Context.Courses
                        where c.IsDelete == false
                        select c;

            //filter || search by Title, Description
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Title.Contains(search) || x.Description.Contains(search));
            }
            return await PaginatedList<Course>.ToPaginatedListAsync(query,
                   pagingRequest.PageNumber,
                   pagingRequest.PageSize);
        }

        /// <summary>
        /// filter course by term
        /// </summary>
        /// <param name="source"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        private IQueryable<Course> TextFilter_Strings(IQueryable<Course> source, string term)
        {
            if (string.IsNullOrEmpty(term)) { return source; }

            var elementType = source.ElementType;


            // Get all the string property names on this specific type.
            var stringProperties =
                elementType.GetProperties()
                    .Where(x => x.PropertyType == typeof(string))
                    .ToArray();
            if (!stringProperties.Any()) { return source; }

            // Build the string expression
            string filterExpr = string.Join(
                " || ",
                stringProperties.Select(prp => $"{prp.Name}.Contains(@0)")
            );

            return source.Where(filterExpr, term);
        }

        /// <summary>
        /// Search course no paging
        /// </summary>
        /// <param name="query"></param>
        /// <returns>List course</returns>
        public async Task<List<Course>> SearchCourse(string query)
        {
            var courses = Context.Courses
                .Include(course => course.AppUser)
                .Include(course => course.Sections).ThenInclude(section => section.Lessons)
                .Include(course => course.OrderDetails)
                .Include(course => course.Category)
                .Include(course => course.EnrollCourses).ThenInclude(enrollCourse => enrollCourse.Review)
                .AsNoTracking()
                .AsQueryable();
            var result = TextFilter_Strings(courses, query);
            return await result.ToListAsync();

        }
        /// <summary>
        /// Get course most buy
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public async Task<PaginatedList<Course>> GetTopCourse(int instructorId, PagingRequest pagingRequest)
        {
            var orderDetails = Context.OrderDetails.GroupBy(
                orderDetail => orderDetail.CourseId)
                .Select(orderDetail => new
                {
                    orderDetail.Key,
                    Count = orderDetail.Count(),
                });
            var coursesOrderDetail = Context.Courses.Join(orderDetails,
                course => course.Id,
                order => order.Key,
                (course, order) => new
                {
                    course,
                    order
                }).OrderByDescending(orderDetail => orderDetail.order.Count)
                .Select(x => x.course);
            return await PaginatedList<Course>.ToPaginatedListAsync(coursesOrderDetail.AsNoTracking().AsQueryable(),
                pagingRequest.PageNumber, pagingRequest.PageSize);
        }
    }
}
using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request;
using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.CourseDiscountDTOs;
using LMS.Model.Request.CourseDTOs;
using LMS.Model.Request.CoursePromotionDTOs;
using LMS.Model.Request.SearchDTOs;
using LMS.Model.Request.SearchDTOs.Enums;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.CategoryDTOs;
using LMS.Model.Response.CourseDiscountDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.CourseFavoriteDTOs;
using LMS.Model.Response.EnrollCourses;
using LMS.Model.Response.SectionDTOs;
using LMS.Model.Response.ShoppingCartDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Enums;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using LMS.Service.Services.QuizSubmissionServices;
using LMS.Service.Services.ReviewServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CourseService> _logger;
        private readonly IMapper _mapper;
        private readonly IQuizSubmissionServices _quizSubmissionServices;
        private readonly IReviewService _reviewService;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly IUserAccessor _userAccessor;

        public CourseService(
            IUnitOfWork unitOfWork,
            ILogger<CourseService> logger,
            IMapper mapper,
            IQuizSubmissionServices quizSubmissionServices,
            IReviewService reviewService,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _quizSubmissionServices = quizSubmissionServices;
            _reviewService = reviewService;
            _responseMessage = responseMessage.Value;
            _userAccessor = userAccessor;
        }

        #region Favorite Course

        public async Task<bool> CreateFavoriteCourseAsync(int courseId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (courseId <= 0) throw new BadRequestException(_responseMessage.InvalidParameters);

                var userId = await _userAccessor.GetUserId();

                var courseFavorite = await _unitOfWork.CourseFavoriteRepository
                    .ExistsAsync(
                        fc => fc.UserId == userId && fc.CourseId == courseId
                    );

                bool result;

                if (courseFavorite)
                {
                    throw new BadRequestException(_responseMessage.InvalidParameters);
                }
                else
                {
                    var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == courseId);

                    if (course is null) throw new NotFoundException(_responseMessage.NotFound);

                    var favoriteCourse = new FavoriteCourse
                    {
                        UserId = userId,
                        CourseId = courseId,
                    };

                    result = await _unitOfWork.CourseFavoriteRepository.AddAsync(favoriteCourse);
                }

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateFavoriteCourseAsync));
                throw;
            }
        }

        public async Task<bool> DeleteAllFavoriteCourseAsync()
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            var result = true;
            try
            {
                var userId = await _userAccessor.GetUserId();

                var favoritesCourses = await _unitOfWork.CourseFavoriteRepository.GetAllFavoriteCourses(userId);

                if (favoritesCourses.Count == 0)
                    throw new NotFoundException(_responseMessage.NotFound);

                result = await _unitOfWork.CourseFavoriteRepository.RemoveMultipleAsync(favoritesCourses);

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred,
                    nameof(DeleteAllFavoriteCourseAsync));
                throw;
            }
        }

        public async Task<bool> DeleteFavoriteCourseAsync(int courseId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (courseId <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var userId = await _userAccessor.GetUserId();

                var favoriteCourse =
                    await _unitOfWork.CourseFavoriteRepository
                    .GetAsync(
                        fc => fc.CourseId == courseId && fc.UserId == userId
                        );

                if (favoriteCourse is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                favoriteCourse.IsDelete = true;

                var result = await _unitOfWork.CourseFavoriteRepository
                    .UpdateAsync(favoriteCourse);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred,
                    nameof(DeleteFavoriteCourseAsync));
                throw;
            }
        }

        public async Task<PagingResult<CourseFavoriteDTO>> GetAllFavoriteCoursesAsync(PagingRequest pagingRequest = null)
        {
            try
            {
                pagingRequest ??= new PagingRequest();

                var userId = await _userAccessor.GetUserId();

                var favorites = await _unitOfWork.CourseFavoriteRepository.GetAllFavoriteCourses(userId, pagingRequest);

                var courseFavoriteDTOs =
                    _mapper.Map<PaginatedList<FavoriteCourse>, PaginatedList<CourseFavoriteDTO>>(favorites);

                foreach (var favoriteDTO in courseFavoriteDTOs)
                {
                    foreach (var favorite in favorites)
                    {
                        if (favorite.Id != favoriteDTO.Id)
                            continue;

                        if (favorite.Course.EnrollCourses.Any())
                        {
                            favoriteDTO.Course.AverageRate = (float)favorite.Course.EnrollCourses.Average(ec => ec.Review.Rating);
                        }
                    }
                }

                var pageResult = new PagingResult<CourseFavoriteDTO>()
                {
                    TotalCount = courseFavoriteDTOs.TotalCount,
                    PageSize = courseFavoriteDTOs.PageSize,
                    TotalPages = courseFavoriteDTOs.TotalPages,
                    CurrentPage = courseFavoriteDTOs.CurrentPage,
                    Objects = courseFavoriteDTOs
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred,
                    nameof(GetAllFavoriteCoursesAsync));
                throw;
            }
        }

        #endregion

        public async Task<PagingResult<CourseDTO>> GetLatestCoursePerformanceInformation(PagingRequest pagingRequest)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {

                var courseDTO = _mapper.Map<PaginatedList<Course>, PaginatedList<CourseDTO>>(await _unitOfWork.CourseRepository
                    .GetLatestCoursePerformanceInformation(pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<CourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<CourseDTO>> GetTotalNumberToInstructorCourses(int courseId,
            PagingRequest pagingRequest)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = _mapper.Map<PaginatedList<Course>, PaginatedList<CourseDTO>>(await _unitOfWork.CourseRepository
                    .GetTotalNumberToInstructorCourses(courseId, pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<CourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<EnrollCourseDTO>> GetTotalStudentEnrollToInstructor(int intstructorId,
            PagingRequest pagingRequest)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {

                var courseDTO = _mapper.Map<PaginatedList<EnrollCourseDTO>>(await _unitOfWork.CourseRepository
                    .GetTotalStudentEnrollToInstructor(intstructorId, pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<EnrollCourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<EnrollCourseDTO>> GetTotalStudentStudiedToInstructor(int courseId,
            PagingRequest pagingRequest)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = _mapper.Map<PaginatedList<EnrollCourse>, PaginatedList<EnrollCourseDTO>>(await _unitOfWork.CourseRepository
                    .GetTotalStudentStudiedToInstructor(courseId, pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<EnrollCourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<ShoppingCartPurchaseOfUserDTO>> GetAllPurchasedCoursesOfStudent(int studentId,
            PagingRequest pagingRequest)
        {
            //await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = await _unitOfWork.ShoppingCartRepository
                    .GetAllPurchasedCoursesOfStudent(studentId, pagingRequest);

                //await _unitOfWork.SaveAsync();
                //await transaction.CommitAsync();
                var PurchasedCourses = _mapper.Map<PaginatedList<ShoppingCartPurchaseOfUserDTO>>(courseDTO);
                var pageResult = new PagingResult<ShoppingCartPurchaseOfUserDTO>()
                {
                    TotalCount = PurchasedCourses.TotalCount,
                    PageSize = PurchasedCourses.PageSize,
                    TotalPages = PurchasedCourses.TotalPages,
                    CurrentPage = PurchasedCourses.CurrentPage,
                    Objects = PurchasedCourses
                };
                return pageResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<CourseDTO>> GetAllCourseAsync(PagingRequest pagingRequest)
        {
            try
            {
                var courseDTO = _mapper.Map<PaginatedList<CourseDTO>>(await _unitOfWork.CourseRepository
                    .GetAllCourseAsync(pagingRequest));
                var pageResult = new PagingResult<CourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<AppUserDTO> GetTeacherByName(string userName)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var userDTO = await _unitOfWork.AppUserRepository
                    .GetTeachByName(userName);

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return _mapper.Map<AppUserDTO>(userDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<CourseDTO>> GetAllCourseByCategoryName(string categoryName, PagingRequest pagingRequest)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var userDTO = _mapper.Map<PaginatedList<CourseDTO>>(await _unitOfWork.CourseRepository
                    .GetAllCourseByCategoryName(categoryName, pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                var pageResult = new PagingResult<CourseDTO>()
                {
                    TotalCount = userDTO.TotalCount,
                    PageSize = userDTO.PageSize,
                    TotalPages = userDTO.TotalPages,
                    CurrentPage = userDTO.CurrentPage,
                    Objects = userDTO
                };
                return pageResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CourseDetailDTO> GetCourse(int courseId)
        {
            try
            {
                if (courseId <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var course =
                    await _unitOfWork.CourseRepository
                        .GetCourseDetailAsync(courseId);

                if (course is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                var userId = await _userAccessor.GetUserId();

                var courseDTO = _mapper.Map<CourseDetailDTO>(course);

                if (userId != 0)
                {
                    courseDTO.IsFavorite = course.FavoriteCourses
                        .Exists(fc => fc.UserId == userId);

                    var userVoter = course.AppUser
                        .UserVoters
                        .FirstOrDefault(uv => uv.VoterId == userId);

                    if (userVoter != null)
                    {
                        courseDTO.HasUpVote = userVoter.IsUpvote ? true : false;
                        courseDTO.HasDownVote = !courseDTO.HasUpVote;
                    }
                }

                var enrollCoursesWithReview = course.EnrollCourses
                    .Where(er => er.Review != null).ToList();

                courseDTO.TotalEnrolled = course.EnrollCourses.Count();
                courseDTO.TotalRatings = enrollCoursesWithReview.Count();

                courseDTO.Rating =
                    enrollCoursesWithReview.Count() == 0 ?
                    0 : enrollCoursesWithReview.Sum(
                        e => e.Review.Rating) / courseDTO.TotalRatings;

                return courseDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetCourse));
                throw;
            }
        }

        public async Task<List<SectionBasicDTO>> GetCourseSections(int courseId)
        {
            try
            {
                if (courseId <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var sections = await _unitOfWork.SectionRepository.GetSectionsForCourseContentAsync(courseId);

                var sectionBasicDTOs = _mapper.Map<List<SectionBasicDTO>>(sections);

                sectionBasicDTOs.ForEach(s => s.Lessons.OrderBy(l => l.Position));

                return sectionBasicDTOs;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetCourseSections));
                throw;
            }
        }

        public async Task<SectionBasicDTO> GetCourseSectionForStudy(int courseId, int sectionId)
        {
            try
            {
                if (courseId <= 0 || sectionId <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var section = await _unitOfWork.SectionRepository.GetASectionForCourseAsync(courseId, sectionId);

                if (section is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                var sectionBasicDTO = _mapper.Map<SectionBasicDTO>(section);

                var userId = await _userAccessor.GetUserId();

                CheckLessonsStatusesFromASection(userId, section, sectionBasicDTO);

                CheckAssignmentsCompletionStatusesInASection(userId, section, sectionBasicDTO);

                CheckQuizzesCompletionStatusesInASection(userId, section, sectionBasicDTO);

                return sectionBasicDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetCourseSectionForStudy));
                throw;
            }
        }

        public async Task<List<SectionBasicDTO>> GetCourseSectionsForStudy(int courseId)
        {
            try
            {
                if (courseId <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var sections = await _unitOfWork.SectionRepository.GetSectionsForCourseContentAsync(courseId);

                if (sections.Count == 0)
                    throw new NotFoundException(_responseMessage.NotFound);

                var sectionBasicDTOs = _mapper.Map<List<SectionBasicDTO>>(sections);

                var userId = await _userAccessor.GetUserId();

                CheckLessonsCompletionStatusesInAListOfSections(userId, sections, sectionBasicDTOs);

                CheckAssignmentsCompletionStatusesInAListOfSections(userId, sections, sectionBasicDTOs);

                var quizzes = GetQuizzesFromAListOfSections(sections);

                CheckQuizzesCompletionStatusesInAListOfQuizzes(userId, quizzes, sectionBasicDTOs);

                return sectionBasicDTOs;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetCourseSectionsForStudy));
                throw;
            }
        }

        public async Task<CourseOverviewDTO> GetCourseOverviewDTOAsync(int courseId)
        {
            try
            {
                if (courseId <= 0)
                    throw new BadRequestException();

                var course = await _unitOfWork.CourseRepository.GetCourseOverviewAsync(courseId);

                if (course is null)
                    throw new NotFoundException();

                var courseOverviewDTO = _mapper.Map<CourseOverviewDTO>(course);

                courseOverviewDTO.TotalStudents = course.EnrollCourses.Count;

                foreach (var enrollCourse in course.EnrollCourses)
                {
                    courseOverviewDTO.TotalReviewed += enrollCourse.Review is null ? 0 : 1;
                }

                if (course.EnrollCourses.Count > 0)
                {
                    courseOverviewDTO.FeaturedReview = await _reviewService.GetAFeaturedReviewAsync(course.Id);

                    foreach (var enrollCourse in course.EnrollCourses)
                    {
                        courseOverviewDTO.TotalReviewed += enrollCourse.Review is null ? 0 : 1;
                    }
                }

                if (course.Sections.Count > 0)
                {
                    foreach (var section in course.Sections)
                    {
                        courseOverviewDTO.TotalDuration += section.TotalTime;
                    }
                }

                return courseOverviewDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetCourseOverviewDTOAsync));
                throw;
            }
        }

        public async Task<List<CourseDTO>> GetCurrentCourse()
        {
            try
            {
                var courseDTO = await _unitOfWork.CourseRepository
                    .GetCurrentCourse();

                return _mapper.Map<List<Course>, List<CourseDTO>>(courseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get top course for analyic instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>List<CourseForInstructorAnlyicDTO></returns>
        public async Task<List<CourseForInstructorAnlyicDTO>> GetTopCourseForAnalyic(int instructorId)
        {
            try
            {
                var listCourse = new List<CourseForInstructorAnlyicDTO>();
                var pagingRequest = new PagingRequest();
                var courses =
                    await _unitOfWork.CourseRepository.GetAllAsync(
                        pagingRequest, x => x.InstructorId == instructorId,
                        i => i.OrderDetails, z => z.CourseComments);
                var courseDTO =
                    _mapper.Map<PaginatedList<Course>, PaginatedList<CourseForInstructorAnlyicDTO>>(courses);
                var courseArray = courseDTO.ToArray();
                foreach (var item in courseArray)
                {
                    item.TotalPurchase = item.OrderDetails.Count;
                    item.TotalComment = item.CourseComments.Count;
                    item.CourseComments = null;
                    item.OrderDetails = null;
                    listCourse.Add(item);
                }

                if (listCourse is null)
                    throw new BadRequestException();

                return listCourse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Create new course failed in service", nameof(GetTopCourseForAnalyic));
                throw;
            }
        }


        public async Task<PurchasedCoursesOfStudentDTO> PrintPurchasedCourses(int enrollId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = await _unitOfWork.CourseRepository
                    .PrintPurchasedCourses(enrollId);
                if (courseDTO is null)
                    throw new NotFoundException();
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return _mapper.Map<PurchasedCoursesOfStudentDTO>(courseDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DisableActiveCourseByIdAsync(int userId, int courseId)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == courseId, c => c.Category, course => course.AppUser);
                if (course == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND("Course id : " + courseId.ToString()));
                if (userId != course.InstructorId)
                    throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
                course.IsDelete = true;
                await _unitOfWork.CourseRepository.UpdateAsync(course);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.UpdateFailure);
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<PagingResult<InstructorCourseDto>> GetAllActiveCourseOfInstructor(int userId, PagingRequest pagingRequest)
        {
            var course = await _unitOfWork.CourseRepository.GetAllActiveCourseAsync(userId, pagingRequest);
            var instructorCourse = course.Select(c => new InstructorCourseDto
            {
                Id = c.Id,
                Title = c.Title,
                PublishDate = c.PublishedDate,
                Sales = c.OrderDetails.Count(),
                Parts = c.Sections.Count(),
                CategoryName = c.Category.Name,
                Status = c.CourseStatus
            }).ToList();

            return new PagingResult<InstructorCourseDto>
            {
                PageSize = course.PageSize,
                TotalPages = course.TotalPages,
                CurrentPage = course.CurrentPage,
                TotalCount = course.TotalCount,
                Objects = instructorCourse
            };
        }

        public async Task<PagingResult<CourseDiscountDTO>> GetAllDiscountCourseOfInstructor(int userId, PagingRequest pagingRequest)
        {
            var course = await _unitOfWork.CourseRepository.GetAllDiscountCourse(userId, pagingRequest);
            if (course == null) throw new NotFoundException(ResponseMessage.GetDataFailed);

            var result = course.SelectMany(c => c.CourseDiscounts.Select(d =>
            new CourseDiscountDTO
            {
                courseDTO = _mapper.Map<CourseDTO>(c),
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                Amount = d.DiscountAmount
            })).ToList();
            return new PagingResult<CourseDiscountDTO>
            {
                PageSize = course.PageSize,
                CurrentPage = course.CurrentPage,
                TotalPages = course.TotalPages,
                TotalCount = result.Count(),
                Objects = result
            };
        }
        public async Task<PagingResult<CourseDTO>> GetAllPendingCourseOfInstructor(int userId, PagingRequest pagingRequest)
        {
            var courseDto = await _unitOfWork.CourseRepository.GetAllPendingCourse(userId, pagingRequest);
            var result = _mapper.Map<PaginatedList<CourseDTO>>(courseDto);
            return new PagingResult<CourseDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                TotalCount = result.TotalCount,
                Objects = result
            };
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int courseId)
        {
            var courseDto = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == courseId, c => c.Category, course => course.AppUser);
            var category = _mapper.Map<CategoryDTO>(courseDto.Category);
            var result = _mapper.Map<CourseDTO>(courseDto);
            result.Category = category;
            return result;
        }
        public async Task<CourseDiscountCreateDTO> CreateCourseDiscountAsync(int userId, CourseDiscountCreateDTO courseDiscountDTO)
        {

            // if course's vendor is not same user account login, cannot create discount for course
            var checkAuthorInCourse = _unitOfWork.CourseRepository.CourseAuthor(courseDiscountDTO.CourseId, userId);
            if (!checkAuthorInCourse) throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
            var checkCourseInDiscount = _unitOfWork.CourseRepository.CourseInDiscount(courseDiscountDTO.CourseId, courseDiscountDTO.StartDate);
            if (checkCourseInDiscount) throw new ConflictException(ResponseMessage.IN_DISCOUNT);
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _unitOfWork.CourseDiscountRepository.AddAsync(_mapper.Map<CourseDiscount>(courseDiscountDTO));
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.AddFailure);
                await transaction.CommitAsync();
                return courseDiscountDTO;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<CourseDiscountEditDTO> UpdateCourseDiscountAsync(int userId, int discountId, CourseDiscountEditDTO courseDiscountDTO)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {

                var course = await _unitOfWork.CourseDiscountRepository.GetAsync(c => c.Id == discountId);
                if (course == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(discountId.ToString()));
                var checkAuthorInCourse = _unitOfWork.CourseRepository.CourseAuthor(course.Id, userId);
                if (!checkAuthorInCourse) throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
                course.DiscountAmount = courseDiscountDTO.DiscountAmount;
                course.StartDate = courseDiscountDTO.StartDate;
                course.EndDate = courseDiscountDTO.EndDate;
                await _unitOfWork.CourseDiscountRepository.UpdateAsync(course);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.UpdateFailure);
                await transaction.CommitAsync();
                return courseDiscountDTO;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> DisposeCourseDiscountAsync(int userId, int discountId)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var course = await _unitOfWork.CourseDiscountRepository.GetAsync(c => c.Id == discountId);
                if (course == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(discountId.ToString()));
                var checkAuthorInCourse = _unitOfWork.CourseRepository.CourseAuthor(course.CourseId, userId);
                if (!checkAuthorInCourse) throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
                course.IsDelete = true;
                await _unitOfWork.CourseDiscountRepository.UpdateAsync(course);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.UpdateFailure);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CoursePromotionCreateDTO> CreatePromotionAsync(int userId, CoursePromotionCreateDTO coursePromotionCreateDTO)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var promotion = _mapper.Map<CoursePromotion>(coursePromotionCreateDTO);
                promotion.VendorId = userId;
                await _unitOfWork.CoursePromotionRepository.AddAsync(promotion);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.AddFailure);
                await transaction.CommitAsync();
                return coursePromotionCreateDTO;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<CoursePromotionCreateDTO> UpdateCoursePromotion(int userId, int promotionId, CoursePromotionCreateDTO coursePromotionCreateDTO)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {

                var promotion = await _unitOfWork.CoursePromotionRepository.GetAsync(p => p.Id == promotionId);
                if (promotion == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(promotionId.ToString()));
                if (promotion.VendorId != userId) throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
                promotion.Tittle = coursePromotionCreateDTO.Tittle;
                promotion.CouponCode = coursePromotionCreateDTO.CouponCode;
                promotion.StartDate = coursePromotionCreateDTO.StartDate;
                promotion.EndDate = coursePromotionCreateDTO.EndDate;
                await _unitOfWork.CoursePromotionRepository.UpdateAsync(promotion);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.UpdateFailure);

                await transaction.CommitAsync();
                return coursePromotionCreateDTO;

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> GetTotalItemOfCourse(int courseId)
        {
            try
            {
                var totalQuiz = await _unitOfWork.CourseRepository.GetTotalQuizOfCourse(courseId);
                var totalLesson = await _unitOfWork.CourseRepository.GetTotalLessonOfCourse(courseId);
                var totalAssignment = await _unitOfWork.CourseRepository.GetTotalAssignmentOfCourse(courseId);
                return (totalQuiz + totalLesson + totalAssignment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        private async Task<int> GetTotalQuizCompletedOfUser(int userID, int courseID)
        {
            try
            {
                var listQuiz = await _unitOfWork.CourseRepository.GetListQuizOfCourse(courseID);
                int totalQuizCompleted = 0;
                foreach (var quizID in listQuiz)
                {
                    var check = await _quizSubmissionServices.CheckQuizSubmissionCompleted(new CheckStatusStudyDTO
                    {
                        UserID = userID,
                        TypeCheckID = quizID
                    });
                    if (check)
                    {
                        totalQuizCompleted++;
                    }
                }
                return totalQuizCompleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task<int> GetTotalItemCompletedOfCourse(int courseId, int userID)
        {
            try
            {
                var totalQuizComleted = await GetTotalQuizCompletedOfUser(userID, courseId);
                var totalLessonComleted = await _unitOfWork.CourseRepository.GetTotalLessonCompletedOfUser(userID, courseId);
                var totalAssignmentComleted = await _unitOfWork.CourseRepository.GetTotalAssignmentCompletedOfUser(userID, courseId);
                return (totalQuizComleted + totalLessonComleted + totalAssignmentComleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<PagingResult<CourseDTO>> GetAllPurchasedCoursesOfSystem(PagingRequest pagingRequest)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = _mapper.Map<PaginatedList<CourseDTO>>(await _unitOfWork.CourseRepository
                    .GetAllPurchasedCoursesOfSystem(pagingRequest));

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                var pageResult = new PagingResult<CourseDTO>()
                {
                    TotalCount = courseDTO.TotalCount,
                    PageSize = courseDTO.PageSize,
                    TotalPages = courseDTO.TotalPages,
                    CurrentPage = courseDTO.CurrentPage,
                    Objects = courseDTO
                };
                return pageResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<CourseDTO>> GetNewPurchasedCoursesIn1Month()
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var courseDTO = await _unitOfWork.CourseRepository
                    .TotalNewPurchasedCoursesIn1Month();

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return _mapper.Map<List<CourseDTO>>(courseDTO);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }



        public async Task<PagingResult<CourseDTO>> GetNewestCourses(PagingRequest pagingRequest)
        {
            var courses = await _unitOfWork.CourseRepository.GetCoursesOrderByDesByPublishDate(pagingRequest);
            var paginatedList = _mapper.Map<PaginatedList<CourseDTO>>(courses);
            foreach (var course in paginatedList)
            {
                course.AverageRate = await _reviewService.GetAverageRatingCourseAsync(course.Id);
            }
            return new PagingResult<CourseDTO>
            {
                PageSize = paginatedList.PageSize,
                CurrentPage = paginatedList.CurrentPage,
                TotalPages = paginatedList.TotalPages,
                TotalCount = paginatedList.TotalCount,
                Objects = paginatedList
            };
        }

        public async Task<PagingResult<CourseDTO>> GetFeaturedCoursesInThisMonth(PagingRequest pagingRequest)
        {
            var courses = await _unitOfWork.CourseRepository.GetCoursesByMonth(pagingRequest);
            var result = _mapper.Map<PaginatedList<CourseDTO>>(courses);
            foreach (var course in result)
            {
                course.AverageRate = await _reviewService.GetAverageRatingCourseAsync(course.Id);
                course.IsBestSeller = true;
            }
            return new PagingResult<CourseDTO>
            {
                PageSize = result.PageSize,
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalCount = result.TotalCount,
                Objects = result
            };
        }

        public async Task<int> CalculateTotalDurationOfACourseAsync(int courseId)
        {
            try
            {
                if (courseId <= 0)
                    throw new BadRequestException();

                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == courseId, c => c.Sections);

                return course.Sections.Sum(section => section.TotalTime);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetCourseOverviewDTOAsync));
                throw;
            }
        }

        /// <summary>
        /// Create new course with basic infor
        /// </summary>
        /// <param name="courseCreate"></param>
        /// <returns>New courseId</returns>
        public async Task<int> CreateCourseBasic(CourseCreateDTO courseCreate)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var userId = await _userAccessor.GetUserId();
                if (courseCreate.Id != null)
                {
                    var editNewCourse = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == courseCreate.Id);
                    if (editNewCourse == null)
                        throw new NotFoundException(ResponseMessage.GetDataFailed);
                    _mapper.Map<CourseCreateDTO, Course>(courseCreate, editNewCourse);
                    editNewCourse.InstructorId = userId;
                    await _unitOfWork.CourseRepository.UpdateAsync(editNewCourse);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    return editNewCourse.Id;
                }
                var newCourse = _mapper.Map<Course>(courseCreate);
                newCourse.CourseStatus = CourseStatus.Draft;
                newCourse.InstructorId = userId;
                var newCourseId = await _unitOfWork.CourseRepository.AddCourseAsync(newCourse);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return newCourseId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1} {2}", "Something went wrong in service",
                    nameof(CreateCourseBasic), ex.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Check if any course draft of user on a day
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>True if have any and false if none</returns>
        public async Task<bool> CheckDraftCourseOfDay(int userId)
        {
            try
            {
                return await _unitOfWork.CourseRepository.CheckDraftCourseOfDay(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in service",
                    nameof(CheckDraftCourseOfDay));
                throw;
            }
        }

        /// <summary>
        /// Finish creating new course by change course status to pending and create certificate for course
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        public async Task<bool> CreateCourse(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id);
                if (course == null) throw new NotFoundException(ResponseMessage.GetDataFailed);
                course.CourseStatus = CourseStatus.Pending;
                course.TotalDuration = await CalculateTotalDurationOfACourseAsync(course.Id);
                await _unitOfWork.CourseRepository.UpdateAsync(course);
                CertificateCreateDTO courseCertificate = new CertificateCreateDTO { CertificateName = course.Title, CourseId = course.Id, IsForCourse = true };
                await _unitOfWork.CertificationRepository.AddAsync(_mapper.Map<Certificate>(courseCertificate));
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in service",
                    nameof(CreateCourse));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Update media on creating new course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mediaCreate"></param>
        /// <returns>True if success</returns>
        public async Task<bool> CreateCourseMedia(int id, CourseMediaCreateDTO mediaCreate)
        {
            if (id != mediaCreate.Id) throw new BadRequestException(ResponseMessage.NOT_MATCH);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id);
                if (course == null) throw new NotFoundException(ResponseMessage.GetDataFailed);
                course.IntroOverviewUrl = mediaCreate.IntroOverviewFile ??= mediaCreate.IntroOverviewUrl;
                course.ThumbNailUrl = mediaCreate.ThumbNail;
                await _unitOfWork.CourseRepository.UpdateAsync(course);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in service",
                    nameof(CreateCourseMedia));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Update course price on creating new course  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="priceCreate"></param>
        /// <returns>True if success</returns>
        public async Task<bool> CreateCoursePrice(int id, CoursePriceCreateDTO priceCreate)
        {
            if (id != priceCreate.Id) throw new BadRequestException(ResponseMessage.NOT_MATCH);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == id);
                if (course == null) throw new NotFoundException(ResponseMessage.GetDataFailed);
                course.OriginalPrice = priceCreate.OriginalPrice;
                course.Price = priceCreate.Price;
                course.RequiredLogIn = priceCreate.RequiredLogIn;
                course.RequireEnroll = priceCreate.RequireEnroll;
                await _unitOfWork.CourseRepository.UpdateAsync(course);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in service",
                    nameof(CreateCoursePrice));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Get newest draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>CourseCreateDTO</returns>
        public async Task<CourseCreateDTO> GetNewestDraftCourse(int userId)
        {
            try
            {
                var newestDraftCourse = await _unitOfWork.CourseRepository.GetNewestDraftCourse(userId);
                if (newestDraftCourse == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                return _mapper.Map<CourseCreateDTO>(newestDraftCourse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in service",
                    nameof(GetNewestDraftCourse));
                throw;
            }
        }

        /// <summary>
        /// Get all draft course of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List draft course of user</returns>
        public async Task<List<CourseDTO>> GetAllDraftCourseOfUser(int userId)
        {
            try
            {
                var allDraftOfUser = await _unitOfWork.CourseRepository.GetAllDraftCourseOfUser(userId);
                if (allDraftOfUser == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                return _mapper.Map<List<CourseDTO>>(allDraftOfUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in service",
                    nameof(GetAllDraftCourseOfUser));
                throw;
            }
        }

        public async Task<bool> DeletePromotionAsync(int userId, int promotionId)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var promotion = await _unitOfWork.CoursePromotionRepository.GetAsync(p => p.Id == promotionId);
                if (promotion == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(promotionId.ToString()));
                if (promotion.VendorId != userId) throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
                promotion.IsDelete = true;
                await _unitOfWork.CoursePromotionRepository.UpdateAsync(promotion);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.UpdateFailure);

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<List<CourseDTO>> SearchCourse(SearchRequest query)
        {
            var courses = await _unitOfWork.CourseRepository.SearchCourse(query.SearchString);

            var courseIQueryable = courses.AsQueryable();
            if (query.Topic != default)
            {
                courseIQueryable = courseIQueryable.Where(q => q.Category.Name == query.Topic);
            }
            if (query.Price != default)
            {
                if (query.Price == SearchPrice.Free)
                {
                    courseIQueryable = courseIQueryable.Where(q => q.Price == 0);
                }
                else
                {
                    courseIQueryable = courseIQueryable.Where(q => q.Price > 0);
                }
            }
            SearchByLevel(ref courseIQueryable, query.Level);
            SearchByRating(ref courseIQueryable, query.Rating);
            SearchByVideoDuration(ref courseIQueryable, query.VideoDuration);
            OrderByWithTerm(ref courseIQueryable, query.OrderBy);
            return _mapper.Map<List<CourseDTO>>(courseIQueryable.ToList());
        }
        private void SearchByLevel(ref IQueryable<Course> courses, Level? level)
        {
            if (level == default)
            {
                return;
            }
            if (level == Level.Beginner)
            {
                courses = courses.Where(q => q.Level == Level.Beginner);
            }
            else if (level == Level.Advanced)
            {
                courses = courses.Where(q => q.Level == Level.Advanced);
            }
            else
            {
                courses = courses.Where(q => q.Level == Level.Intermediate);
            }
        }
        private void SearchByRating(ref IQueryable<Course> courses, SearchRating? rating)
        {
            if (rating == default)
            {
                return;
            }
            switch (rating)
            {
                case SearchRating.Rating_1:
                    courses = courses.Where(q => q.EnrollCourses.All(x => x.Review.Rating >= 2));
                    break;
                case SearchRating.Rating_2:
                    courses = courses.Where(q => q.EnrollCourses.All(x => x.Review.Rating >= 3));
                    break;
                case SearchRating.Rating_3:
                    courses = courses.Where(q => q.EnrollCourses.All(x => x.Review.Rating >= 4));
                    break;
                case SearchRating.Rating_4:
                    courses = courses.Where(q => q.EnrollCourses.All(x => x.Review.Rating >= 5));
                    break;
            }
        }
        private void SearchByVideoDuration(ref IQueryable<Course> courses, SearchDuration? duration)
        {

            if (duration == default)
            {
                return;
            }
            switch (duration)
            {

                case SearchDuration.Hours_1:
                    courses = courses.Where(q => q.TotalDuration / 3600 >= 0 && q.TotalDuration / 3600 < 3);
                    break;
                case SearchDuration.Hours_2:
                    courses = courses.Where(q => q.TotalDuration / 3600 > 3 && q.TotalDuration / 3600 <= 7);
                    break;
                case SearchDuration.Hours_3:
                    courses = courses.Where(q => q.TotalDuration / 3600 > 7 && q.TotalDuration / 3600 <= 18);
                    break;
                case SearchDuration.Hours_4:
                    courses = courses.Where(q => q.TotalDuration / 3600 > 18);
                    break;
            }
        }
        private void OrderByWithTerm(ref IQueryable<Course> courses, OrderBy? orderBy)
        {
            if (orderBy == default)
            {
                return;
            }
            switch (orderBy)
            {
                case OrderBy.MostReviewed:
                    courses = courses.OrderByDescending(x => x.EnrollCourses.Count());
                    break;
                case OrderBy.HighestPrice:
                    courses = courses.OrderByDescending(x => x.Price);
                    break;
                case OrderBy.Newest:
                    courses = courses.OrderByDescending(x => x.PublishedDate);
                    break;
                case OrderBy.LowestPrice:
                    courses = courses.OrderBy(x => x.PublishedDate);
                    break;
                default:
                    courses = courses.OrderByDescending(x => x.Description);
                    break;
            }
        }

        public async Task<PagingResult<CourseTitlePriceDTO>> TopCourseBuy(int instructorId, PagingRequest pagingRequest)
        {
            var courses = await _unitOfWork.CourseRepository.GetTopCourse(instructorId, pagingRequest);
            if (courses == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(instructorId.ToString()));
            var paginatedListCourse = _mapper.Map<PaginatedList<CourseTitlePriceDTO>>(courses);
            return new PagingResult<CourseTitlePriceDTO>
            {
                PageSize = paginatedListCourse.PageSize,
                CurrentPage = paginatedListCourse.CurrentPage,
                TotalCount = paginatedListCourse.TotalCount,
                TotalPages = paginatedListCourse.TotalPages,
                Objects = paginatedListCourse
            };
        }

        public async Task<bool> IsExistsAsync(int courseId)
        {
            try
            {
                if (courseId <= 0) throw new ArgumentException(_responseMessage.InvalidParameters);

                return await _unitOfWork.CourseRepository.ExistsAsync(c => c.Id == courseId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(IsExistsAsync));
                throw;
            }
        }

        #region Local methods

        /// <summary>
        /// This method gets a list of quiz submissions from a section
        /// </summary>
        /// <param name="section">A section object to get quiz submissions from</param>
        /// <returns>a list of QuizSubmission objects</returns>
        private static IEnumerable<QuizSubmission> GetQuizSubmissionsFromASection(Section section)
        {
            return section.QuizSections
                .Where(qs => qs.Quiz.QuizSubmissions.Count > 0)
                .SelectMany(qs => qs.Quiz.QuizSubmissions);
        }

        /// <summary>
        /// This method check the completion statuses of quizzes in a section.
        /// </summary>
        /// <param name="userId">Id of an user studying this section</param>
        /// <param name="section">A section for checking</param>
        /// <param name="sectionBasicDTO">A section DTO to update</param>
        private void CheckQuizzesCompletionStatusesInASection(int userId, Section section, SectionBasicDTO sectionBasicDTO)
        {
            var quizSubmissions = GetQuizSubmissionsFromASection(section);

            foreach (var quizBasicDTO in
                     from quizSubmission in quizSubmissions
                     where quizSubmission.UserId == userId &&
                           quizSubmission.IsPassed
                     from quizSectionDTO in sectionBasicDTO.QuizSections
                     where quizSectionDTO.Quiz.Id == quizSubmission.Quiz.Id
                     select quizSectionDTO.Quiz)
            {
                quizBasicDTO.IsComplete = true;
            }
        }

        /// <summary>
        /// This method get a list of assignments completion statuses in a section
        /// </summary>
        /// <param name="userId">Id of an user studying these sections</param>
        /// <param name="section">A section to check from</param>
        /// <param name="sectionBasicDTO">A section DTO to update</param>
        private void CheckAssignmentsCompletionStatusesInASection(int userId, Section section, SectionBasicDTO sectionBasicDTO)
        {
            foreach (var assignmentBasicDTO in
                     from assignment in section.Assignments
                     from assignmentSubmission in assignment.AssignmentSubmissions
                     where assignmentSubmission != null &&
                           assignmentSubmission.UserId == userId &&
                           assignmentSubmission.PercentCompleted >= 80f
                     from assignmentBasicDTO in sectionBasicDTO.Assignments
                     where assignmentBasicDTO.Id == assignment.Id
                     select assignmentBasicDTO)
            {
                assignmentBasicDTO.IsComplete = true;
            }
        }

        /// <summary>
        /// This method checks and updates a list of lessons completion statuses in a list of sections
        /// </summary>
        /// <param name="userId">Id of an user studying these sections</param>
        /// <param name="section">A section to check from</param>
        /// <param name="sectionBasicDTO">A section DTO to update</param>
        private static void CheckLessonsStatusesFromASection(int userId, Section section, SectionBasicDTO sectionBasicDTO)
        {
            foreach (var lessonBasicDTO in from lesson in section.Lessons
                                           from lessonCompletion in lesson.LessonCompletions
                                           where lessonCompletion != null &&
                                                 lessonCompletion.UserId == userId
                                           from lessonBasicDTO in sectionBasicDTO.Lessons
                                           where lessonBasicDTO.Id == lesson.Id
                                           select lessonBasicDTO)
            {
                lessonBasicDTO.IsComplete = true;
            }
        }

        /// <summary>
        /// This method get a list of submitted quizzes.
        /// </summary>
        /// <param name="sections">A list of sections to get quizzes from</param>
        /// <returns>A list of submitted quizzes</returns>
        private static IEnumerable<Quiz> GetQuizzesFromAListOfSections(IEnumerable<Section> sections)
        {
            return from section in sections
                   from quizSection in section.QuizSections
                   where quizSection.Quiz.QuizSubmissions.Count > 0
                   select quizSection.Quiz;
        }

        /// <summary>
        /// This method check the completion statuses of quizzes in a list of sections.
        /// </summary>
        /// <param name="userId">Id of an user studying this section</param>
        /// <param name="quizzes">A list of quizzes for checking</param>
        /// <param name="sectionBasicDTOs">A list of section DTOs to update</param>
        private static void CheckQuizzesCompletionStatusesInAListOfQuizzes(int userId, IEnumerable<Quiz> quizzes, IEnumerable<SectionBasicDTO> sectionBasicDTOs)
        {
            foreach (var quizBasicDTO in
                     from quiz in quizzes
                     from quizSubmission in quiz.QuizSubmissions
                     where quizSubmission.UserId == userId &&
                           quizSubmission.IsPassed
                     from sectionBasicDTO in sectionBasicDTOs
                     from quizSectionDTO in sectionBasicDTO.QuizSections
                     where quizSectionDTO.Quiz.Id == quiz.Id
                     select quizSectionDTO.Quiz)
            {
                quizBasicDTO.IsComplete = true;
            }
        }

        /// <summary>
        /// This method get a list of assignments completion statuses in a list of sections
        /// </summary>
        /// <param name="userId">Id of an user studying these sections</param>
        /// <param name="sections">A list of sections to check from</param>
        /// <param name="sectionBasicDTOs">A list of section DTOs to update</param>
        private static void CheckAssignmentsCompletionStatusesInAListOfSections(int userId, IEnumerable<Section> sections, IEnumerable<SectionBasicDTO> sectionBasicDTOs)
        {
            foreach (var assignmentBasicDTO in
                     from section in sections
                     from assignment in section.Assignments
                     from assignmentSubmission in assignment.AssignmentSubmissions
                     where assignmentSubmission != null &&
                           assignmentSubmission.UserId == userId &&
                           assignmentSubmission.PercentCompleted >= 80f
                     from sectionBasicDTO in sectionBasicDTOs
                     from assignmentBasicDTO in sectionBasicDTO.Assignments
                     where assignmentBasicDTO.Id == assignment.Id
                     select assignmentBasicDTO)
            {
                assignmentBasicDTO.IsComplete = true;
            }
        }

        /// <summary>
        /// This method checks and updates a list of lessons completion statuses in a list of sections
        /// </summary>
        /// <param name="userId">Id of an user studying these sections</param>
        /// <param name="sections">A list of sections to check from</param>
        /// <param name="sectionBasicDTOs">A list of section DTOs to update</param>
        private static void CheckLessonsCompletionStatusesInAListOfSections(int userId, IEnumerable<Section> sections, IEnumerable<SectionBasicDTO> sectionBasicDTOs)
        {
            foreach (var lessonBasicDTO in
                     from section in sections
                     from lesson in section.Lessons
                     from lessonCompletion in lesson.LessonCompletions
                     where lessonCompletion != null
                           && lessonCompletion.UserId == userId
                     from sectionBasicDTO in sectionBasicDTOs
                     from lessonBasicDTO in sectionBasicDTO.Lessons
                     where lessonBasicDTO.Id == lesson.Id
                     select lessonBasicDTO)
            {
                lessonBasicDTO.IsComplete = true;
            }
        }

        public async Task<bool> DeletePendingCourse(int userId, int courseId)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var course = await _unitOfWork.CourseRepository.GetAsync(c => c.Id == courseId && c.CourseStatus == CourseStatus.Pending);
                if (course == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(courseId.ToString()));
                var checkAuthorInCourse = _unitOfWork.CourseRepository.CourseAuthor(course.Id, userId);
                if (!checkAuthorInCourse) throw new AuthorizedException(ResponseMessage.ACCESS_DENIED);
                course.IsDelete = true;
                await _unitOfWork.CourseRepository.UpdateAsync(course);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.UpdateFailure);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        #endregion
    }
}
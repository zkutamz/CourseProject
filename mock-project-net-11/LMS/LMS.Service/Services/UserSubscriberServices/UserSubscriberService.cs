using AutoMapper;
using LMS.Model.Response.RevenueStatisticsDTOs;
using LMS.Model.Response.UserSubscriberDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.UserSubscriberServices
{
    public class UserSubscriberService : IUserSubscriberService
    {
        private readonly ILogger<UserSubscriberService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UserSubscriberService(
            ILogger<UserSubscriberService> logger,
            IUnitOfWork unitOfWork,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            IUserAccessor userAccessor,
            IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _responseMessage = responseMessage.Value;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<int> GetTotalInstrutorsSubscribing()
        {
            try
            {
                var subscriberId = await _userAccessor.GetUserId();

                var userSubscribers = await _unitOfWork.UserSubcriberRepository.GetAllAsyncNoPaging(us => us.SubcriberId == subscriberId);

                return userSubscribers.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalInstrutorsSubscribing));
                throw;
            }

        }

        public async Task<int> GetTotalStudentSubscribing()
        {
            try
            {
                var userId = await _userAccessor.GetUserId();

                var userSubscribers = await _unitOfWork.UserSubcriberRepository.GetAllAsyncNoPaging(us => us.UserId == userId);

                return userSubscribers.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalStudentSubscribing));
                throw;
            }
        }

        public async Task<List<UserSubscriberBasicDTO>> GetTotalNewInstrutorsSubscribing()
        {
            try
            {
                var newInstructors =
                    await _unitOfWork.UserSubcriberRepository.GetTotalNewInstrutorsSubscribing();

                return _mapper.Map<List<UserSubscriberBasicDTO>>(newInstructors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalSubcriber));
                throw;
            }
        }
        public async Task<List<UserSubscriberBasicDTO>> GetTotalNewStudenSubscribing()
        {
            try
            {
                var newInstructors =
                    await _unitOfWork.UserSubcriberRepository.GetTotalNewStudentSubscribing();

                return _mapper.Map<List<UserSubscriberBasicDTO>>(newInstructors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalSubcriber));
                throw;
            }
        }


        public async Task<int> GetTotalSubcriber(int userId)
        {
            try
            {
                var pagingRequest = new PagingRequest();
                int totalSubcriber = 0;
                var allSubcriber =
                    await _unitOfWork.UserSubcriberRepository.GetAllAsync(pagingRequest, x => x.UserId == userId);
                totalSubcriber = allSubcriber.Count;

                return totalSubcriber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalSubcriber));
                throw;
            }

        }

        public async Task<UserSubcriber> GetUserSubcriberAsync(int userId, int subscriberId)
        {
            try
            {
                var userSubscriber =
                    await _unitOfWork.UserSubcriberRepository
                    .GetAsync(
                        us => us.UserId == userId && us.SubcriberId == subscriberId
                    );

                return userSubscriber;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalSubcriber));
                throw;
            }
        }

        public async Task<bool> CreateSubscriptionAsync(int userId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var subscriberId = await _userAccessor.GetUserId();

                var subsription = new UserSubcriber
                {
                    SubcriberId = subscriberId,
                    UserId = userId
                };

                var result = await _unitOfWork.UserSubcriberRepository.AddAsync(subsription);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalSubcriber));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteSubscriptionAsync(UserSubcriber userSubcriber)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var result = await _unitOfWork.UserSubcriberRepository.RemoveAsync(userSubcriber);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetTotalSubcriber));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<UserSubscriberDTO>> GetStudentsSubscribedAsync(PagingRequest pagingRequest)
        {
            try
            {
                var userId = await _userAccessor.GetUserId();

                var userSubscribers = await _unitOfWork.UserSubcriberRepository.GetStudentsSubscribedAsync(userId, pagingRequest);

                var userSubscriberDTOs = _mapper.Map<PaginatedList<UserSubcriber>, PaginatedList<UserSubscriberDTO>>(userSubscribers);

                return new PagingResult<UserSubscriberDTO>
                {
                    CurrentPage = userSubscribers.CurrentPage,
                    PageSize = userSubscribers.PageSize,
                    TotalCount = userSubscribers.TotalCount,
                    TotalPages = userSubscribers.TotalPages,
                    Objects = userSubscriberDTOs
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetStudentsSubscribedAsync));
                throw;
            }
        }
        public async Task<List<RevenueDTO>> GetRevenueStatisticsSubscribing(int userId)
        {
            try
            {
                var data =
                    await _unitOfWork.UserSubcriberRepository.GetTotalInstrutorsSubscribing();
                var filter = data.GroupBy(x => x.CreatedAt.Month).Select(x => new RevenueDTO()
                {
                    Month = x.Key,
                    Value = x.Count()

                }).ToList();

                return filter;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetTotalSubcriber));
                throw;
            }
        }

        public async Task<List<RevenueDTO>> GetRevenueStatisticsRandomData()
        {
            var revenue = new List<RevenueDTO>();
            for (int i = 1; i <= 12; i++)
            {
                Random rand = new Random();
                int randomNumber = rand.Next(10, 99);
                revenue.Add(new RevenueDTO()
                {
                    Month = i,
                    Value = randomNumber

                });

            }
            return revenue;
        }
        public async Task<PagingResult<UserSubscriberDTO>> GetInstrutorsSubsribedAsync(PagingRequest pagingRequest)
        {
            try
            {
                var subscriberId = await _userAccessor.GetUserId();

                var userSubscribers = await _unitOfWork.UserSubcriberRepository.GetInstrutorsSubsribedAsync(subscriberId, pagingRequest);

                var userSubscriberDTOs = _mapper.Map<PaginatedList<UserSubcriber>, PaginatedList<UserSubscriberDTO>>(userSubscribers);

                foreach (var userSubscriber in userSubscriberDTOs)
                {
                    foreach (var course in userSubscriber.User.Courses)
                    {
                        userSubscriber.User.TotalStudents += course.EnrollCourses.Count;
                    }
                }

                return new PagingResult<UserSubscriberDTO>
                {
                    CurrentPage = userSubscribers.CurrentPage,
                    PageSize = userSubscribers.PageSize,
                    TotalCount = userSubscribers.TotalCount,
                    TotalPages = userSubscribers.TotalPages,
                    Objects = userSubscriberDTOs
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetInstrutorsSubsribedAsync));
                throw;
            }
        }
    }
}
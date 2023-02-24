using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LMS.Model.Response.OrderHeaderDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace LMS.Service.Services.OrderHeaderServices
{
    public class OrderHeaderService : IOrderHeaderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderHeaderService> _logger;
        private readonly IMapper _mapper;

        public OrderHeaderService(IUnitOfWork unitOfWork, ILogger<OrderHeaderService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PagingResult<OrderHeaderDetailDTO>> GetAllOrdersOfAnInstructorsCourses(int instructorId,
            PagingRequest pagingRequest = null)
        {
            try
            {
                pagingRequest ??= new PagingRequest();

                var courses =
                    await _unitOfWork.CourseRepository.GetAllCoursesOfAnInstructorWithoutPagingAsync(instructorId);

                var orders =
                    await _unitOfWork.OrderHeaderRepository.GetAllAsync(pagingRequest, null, o => o.OrderDetails);

                foreach (var course in courses)
                {
                    for (var i = 0; i < orders.Count; i++)
                    {
                        for (var j = 0; j < orders[i].OrderDetails.Count; j++)
                        {
                            if (orders[i].OrderDetails[j].CourseId != course.Id)
                            {
                                orders.Remove(orders[i]);
                            }
                        }
                    }
                }

                var orderHeaderDetailDTOs =
                    _mapper.Map<PaginatedList<OrderHeader>, PaginatedList<OrderHeaderDetailDTO>>(orders);

                return new PagingResult<OrderHeaderDetailDTO>
                {
                    CurrentPage = orderHeaderDetailDTOs.CurrentPage,
                    TotalPages = orderHeaderDetailDTOs.TotalPages,
                    PageSize = orderHeaderDetailDTOs.PageSize,
                    TotalCount = orderHeaderDetailDTOs.TotalCount,
                    Objects = orderHeaderDetailDTOs
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetAllOrdersOfAnInstructorsCourses));
                throw;
            }
        }

        public Task<PagingResult<OrderHeaderDTO>> GetTopCourse(int instructorId)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalSaleOfAnInstructor(int instructorId)
        {
            var orders = await _unitOfWork.OrderHeaderRepository.GetAllAsyncNoPaging(order => order.SessionId == instructorId);
            decimal total = 0;
            foreach (var order in orders)
            {
                total += order.OrderTotal;
            }
            return total;
        }

        public async Task<decimal> GetTotalSaleOfAnInstructorInThisMonth(int instructorId)
        {
            var thisMonth = DateTime.Now.Month;
            var thisYear = DateTime.Now.Year;
            var orders = await _unitOfWork.OrderHeaderRepository.GetAllAsyncNoPaging(order => order.SessionId == instructorId 
            && order.CreatedAt.Month == thisMonth && order.CreatedAt.Year == thisYear);
            decimal total = 0;
            foreach(var order in orders)
            {
                total += order.OrderTotal;
            }
            return total;
        }
        
    }
}

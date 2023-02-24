using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Model.Response.OrderHeaderDTOs;
using LMS.Repository.Paging;

namespace LMS.Service.Services.OrderHeaderServices
{
    public interface IOrderHeaderService
    {
        Task<PagingResult<OrderHeaderDetailDTO>> GetAllOrdersOfAnInstructorsCourses(int instructorId,
            PagingRequest pagingRequest = null);
        Task<decimal> GetTotalSaleOfAnInstructor(int instructorId);
        Task<decimal> GetTotalSaleOfAnInstructorInThisMonth(int instructorId);
        Task<PagingResult<OrderHeaderDTO>> GetTopCourse(int instructorId);
    }
}

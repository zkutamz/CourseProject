using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.VisitorServices
{
    public class VisitorService : IVisitorService
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VisitorService(ILogger<VisitorService> logger, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Dictionary<int,int>> GetTotalViewWeekly(int instructorId,string date)
        {
            try
            {
                date = date.Replace("%2F", "/");
                DateTime dateTime = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return await _unitOfWork.VisitorRepository.GetTotalViewOfInstructorWeekly(instructorId, dateTime.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetViewDaily));
                throw;
            }
        }

        public Task<int> GetViewDaily(int instructorId, string date)
        {
            try
            {
                date = date.Replace("%2F", "/");
                DateTime dateTime = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return _unitOfWork.VisitorRepository.GetTotalViewOfInstructorByDay(instructorId, dateTime.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetViewDaily));
                throw;
            }
        }
    }
}

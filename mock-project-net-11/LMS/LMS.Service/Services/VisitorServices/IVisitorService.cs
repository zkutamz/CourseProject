using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.VisitorServices
{
    public interface IVisitorService
    {
        public Task<int> GetViewDaily(int instructorId, string date);//Date mm/dd/yyyy
        public Task<Dictionary<int,int>> GetTotalViewWeekly(int instructorId, string date);// total view the last 7 day
    }
}

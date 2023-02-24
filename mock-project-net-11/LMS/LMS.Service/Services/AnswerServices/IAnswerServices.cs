using LMS.Model.Request.AnswerDTOs;
using LMS.Model.Response.AnswerDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.AnswerServices
{
    public interface IAnswerServices
    {
        Task<List<AnswerDTO>> CreateAnswersAsync(List<AnswerCreateDTO> request);
    }
}

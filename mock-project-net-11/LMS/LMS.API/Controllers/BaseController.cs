using LMS.Model.Constant;
using LMS.Model.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LMS.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult HandleResult<T>(T result, string action = null)
        {
            if (!result!.Equals(default))
            {
                var response = new ResponseResult<T>
                {
                    Errors = default,
                    Data = result
                };
                switch (action)
                {
                    case LmsAction.Add:
                        response.StatusCode = (int)HttpStatusCode.Created;
                        response.Message = ResponseMessage.AddSuccess;
                        break;
                    case LmsAction.Update:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        response.Message = ResponseMessage.UpdateSuccess;
                        break;
                    case LmsAction.Delete:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        response.Message = ResponseMessage.DeleteSuccess;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.OK;
                        response.Message = HttpStatusCode.OK.ToString();
                        break;
                }
                return Ok(response);
            }
            return BadRequest(new ResponseResult<T>
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = HttpStatusCode.BadRequest.ToString(),
                Errors = default,
                Data = default
            });
        }
    }
}
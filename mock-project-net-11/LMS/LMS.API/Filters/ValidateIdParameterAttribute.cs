using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LMS.API.Filters
{
    public class ValidateIdParameterAttribute : ActionFilterAttribute
    {
        private const string InvalidId = "The ID provided is invalid. Must be greater than 0.";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int) context.ActionArguments["id"];

                if (id <= 0)
                    context.Result = new BadRequestObjectResult(InvalidId);
            }
            
            if (context.ActionArguments.ContainsKey("userId"))
            {
                var userId = (int)context.ActionArguments["userId"];

                if (userId <= 0)
                    context.Result = new BadRequestObjectResult(InvalidId);
            }
            
            if (context.ActionArguments.ContainsKey("courseId"))
            {
                var courseId = (int) context.ActionArguments["courseId"];

                if (courseId <= 0)
                    context.Result = new BadRequestObjectResult(InvalidId);
            }
        }
    }
}

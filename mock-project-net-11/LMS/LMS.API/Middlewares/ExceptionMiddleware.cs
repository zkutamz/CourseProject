using LMS.Model.Exceptions;
using LMS.Model.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace LMS.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleException(context, exception);
            }
        }
        private static async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = new ResponseResult<string>
            {
                Errors = default,
                Data = default
            };
            switch (exception)
            {
                case NotFoundException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = exception.Message;
                    break;
                case BadRequestException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = exception.Message;
                    break;
                case AuthorizedException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.Message = exception.Message;
                    break;
                case ConflictException e:
                    context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    response.Message = exception.Message;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = exception.Message;
                    break;
            }

            response.StatusCode = context.Response.StatusCode;

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }

    }
}
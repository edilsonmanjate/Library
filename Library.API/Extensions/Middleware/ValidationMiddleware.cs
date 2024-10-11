using Library.Application.Common.Bases;
using Library.Application.Common.Exceptions;

using System.Text.Json;

namespace Library.API.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BadRequestException ex)
            {
                context.Response.ContentType = "application/json";
                var errors = ex.Errors.Select(e => new BaseError { ErrorMessage = e });
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object> { Message = "Validation Errors", Errors = errors });
            }
        }
    }
}

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace PCT.WebAPI.Middleware;

public sealed class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            
            _logger.LogError(exception, exception.Message);

            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server Error",
                Type = exception.GetType().ToString()
            };
            
            context.Response.StatusCode= details.Status.Value;
            
            var result = JsonSerializer.Serialize(new { details = details });
            await response.WriteAsync(result);
        }
    }
}
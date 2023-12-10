using Newtonsoft.Json;
using WorldOfBooks.Application.Exceptions;

namespace WorldOfBooks.WebApi.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
        _request = request;
    }

    public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
    {
        try
        {
            await _request(context);
        }

        catch (ClientException exception)
        {
            var obj = new
            {
                StatusCode = (int)exception.StatusCode,
                ErrorMessage = exception.TitleMessage
            };

            context.Response.StatusCode = (int)exception.StatusCode;
            context.Response.Headers.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(obj);
            await context.Response.WriteAsync(json);
        }

        catch (Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.Headers.ContentType = "application/json";

            if (environment.IsDevelopment())
            {
                await context.Response.WriteAsync(exception.Message);
            }
            else if (environment.IsProduction()) { }
            {
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
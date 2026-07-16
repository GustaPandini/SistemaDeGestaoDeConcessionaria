using SistemaGestaoDeConcessionaria.API.Erros;
using SistemaGestaoDeConcessionaria.Application.Execptions;
using System.Text.Json;

namespace SistemaGestaoDeConcessionaria.API.Middlewear
{
    public class ExcecptionMiddlewear
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcecptionMiddlewear> _logger;
        private readonly IHostEnvironment _env;

        private ExcecptionMiddlewear(RequestDelegate next, ILogger<ExcecptionMiddlewear> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                int statusCode = ex switch
                {
                    NotFoundExecption => StatusCodes.Status404NotFound,
                    BadRequestExecption => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";

                var response = _env.IsDevelopment()
                    ? new ApiExecption(statusCode.ToString(), ex.Message, ex.StackTrace?.ToString())
                    : new ApiExecption(statusCode.ToString(), ex.Message, "Erro interno no server");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await httpContext.Response.WriteAsJsonAsync(json);
            }
        }
    }
}

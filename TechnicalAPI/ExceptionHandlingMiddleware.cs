using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TechnicalAPI
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "No se puede procesar la solicitud");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string message;

            if (exception is ValidationException validationException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Solicitud incorrecta.";
            }
            else if (exception is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                message = "Recurso no encontrado.";
            }
            else
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                message = "Ocurrió un error inesperado.";
            }

            var response = new
            {
                excepcion = message,
                descripcion = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }



}

using business.Exceptions;
using System;
using System.Net;
using System.Text;

namespace SiteParsingApi.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger<ExceptionMiddleware> logger;


        public ExceptionMiddleware(RequestDelegate request, ILogger<ExceptionMiddleware> logger)
        {
            this.request = request;
            this.logger = logger;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (WrongUrlException wrongUrlException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                context.Response.ContentType = "text";
                logger.LogError(wrongUrlException, "" + DateTime.Now + " " + wrongUrlException.Message);
                await context.Response.WriteAsync(wrongUrlException.Message, Encoding.UTF8);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text";
                logger.LogError(exception, "" + DateTime.Now + " " + "Неизвестная ошибка : " + exception.Message);
                await context.Response.WriteAsync("Неизвестная ошибка : " + exception.Message, Encoding.UTF8);
            }

        }
    }
}

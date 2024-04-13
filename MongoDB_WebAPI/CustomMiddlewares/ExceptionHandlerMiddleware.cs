using Core.Extensions;
using FluentValidation.Results;

namespace Presentation.API.CustomMiddlewares
{
    public class ExceptionHandlerMiddleware 
    {
        RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {



            try
            {
                await _next.Invoke(context);

            }
            catch (Exception ex )
            {
                context.Response.ContentType = "application/json";
                context.Response.WriteAsync(ex.Message);
                
            }






        }
    }
}

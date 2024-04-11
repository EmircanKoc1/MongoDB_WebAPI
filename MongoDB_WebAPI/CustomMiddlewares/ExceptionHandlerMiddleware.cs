
namespace Presentation.API.CustomMiddlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {






            await next.Invoke(context);



        }
    }
}

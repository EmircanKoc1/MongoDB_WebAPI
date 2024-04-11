using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.API.CustomActionFilters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.ModelState.IsValid)
            {


            }


            await next();


        }
    }
}

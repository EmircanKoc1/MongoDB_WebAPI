using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.API.CustomActionFilters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.ToDictionary(key => key.Key, value => value.Value.Errors.Select(x=>x.ErrorMessage));


                context.Result = new BadRequestObjectResult(errors);

                return;
            }



            await next();


        }


    }
}

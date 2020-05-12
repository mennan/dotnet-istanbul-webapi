using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetIstanbul.WebApi.Helpers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(m => m.Value.Errors)
                    .Select(m => m.ErrorMessage)
                    .ToList();
                
                context.Result = new BadRequestObjectResult(new ApiReturn
                {
                    Message = "Form data not validated.",
                    InternalMessage = "Many validation errors.",
                    Data = errors
                });
            }
            
            base.OnActionExecuting(context);
        }
    }
}
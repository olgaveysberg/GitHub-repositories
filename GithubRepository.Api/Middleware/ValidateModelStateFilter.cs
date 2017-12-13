using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace GithubRepository.Api.Middleware
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <inheritdoc />
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context
                .ActionArguments
                .Where(x => x.Value == null)
                .ToList()
                .ForEach(x => context.ModelState.AddModelError(x.Key, $"'{x.Key}' must not be null."));

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }


    }
}

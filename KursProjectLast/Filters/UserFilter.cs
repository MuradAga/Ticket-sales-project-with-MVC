using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KursProjectLast.Filters
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? key = context.HttpContext.Session.GetString("key");
            if (key == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"action", "Index" }, {"controller", "Login"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}

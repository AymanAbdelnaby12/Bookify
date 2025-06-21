using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Bookify.Filter
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var request = routeContext.HttpContext.Request;
            var isAjaxRequest = request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return isAjaxRequest ;
        }
    }
}

using MakerBook.Enum;
using MakerBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace MakerBook.Filters
{
    public class RestrictedPageAdminOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userSession = context.HttpContext.Session.GetString("sessionUserLogged");

            if (string.IsNullOrEmpty(userSession))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userSession);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (user.Profile != ProfileEnum.Administrator)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace COLLEGE.Filters
{
    public class AdminOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var isAdmin = session.GetString("IsAdmin");

            //  Exclude Login and AccountController
            var controller = context.RouteData.Values["controller"]?.ToString()?.ToLower();
            var action = context.RouteData.Values["action"]?.ToString()?.ToLower();
        

                if (controller == "account" && (action == "login" || action == "logout"))
            {

               
                return;
            }

            if (isAdmin != "true")
            {
                var requestedUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
                context.HttpContext.Session.SetString("ReturnUrl", requestedUrl);

                context.Result = new RedirectToActionResult("Login", "Account", null);
            }

        }
    }
}

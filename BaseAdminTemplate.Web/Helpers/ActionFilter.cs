using System;
using Microsoft.AspNetCore.Mvc.Filters;

using BaseAdminTemplate.Web.Controllers;

namespace BaseAdminTemplate.Web.Helpers
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is BaseController baseController)
            {
                baseController.ViewBag.MenuItems = baseController.GetMenuItems();
            }
        }
    }
}
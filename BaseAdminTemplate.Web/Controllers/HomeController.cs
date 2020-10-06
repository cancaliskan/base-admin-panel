using System.ComponentModel;
using System.Diagnostics;
using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;
using BaseAdminTemplate.Web.Models;

namespace BaseAdminTemplate.Web.Controllers
{
    [DisplayName(Constants.DisplayInMenu + "Parent Menu")]
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService, IPermissionService permissionService,
                              IRoleService roleService, IMenuService menuService, IExceptionLogService exceptionLogService) 
                            : base(userService, permissionService, roleService, menuService, exceptionLogService)
        {
        }

        [DisplayName(Constants.DisplayInMenu + "Sub Menu Display")]
        public IActionResult Index()
        {
            return View();
        }

        [DisplayName("Sub Menu Display")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

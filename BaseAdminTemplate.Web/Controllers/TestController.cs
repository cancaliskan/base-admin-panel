using System.ComponentModel;
using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BaseAdminTemplate.Web.Controllers
{
    [DisplayName(Constants.DisplayInMenu + "Parent Menu 2")]
    public class TestController : BaseController
    {
        public TestController(IUserService userService, IPermissionService permissionService,
                              IRoleService roleService, IMenuService menuService, IExceptionLogService exceptionLogService)
                              : base(userService, permissionService, roleService, menuService, exceptionLogService)
        {
        }

        // GET
        [DisplayName(Constants.DisplayInMenu + "Sub Menu 2")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
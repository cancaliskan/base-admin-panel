using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using BaseAdminTemplate.Business.Contracts;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService, IPermissionService permissionService,
                              IRoleService roleService, IMenuService menuService, IExceptionLogService exceptionLogService)
                            : base(userService, permissionService, roleService, menuService, exceptionLogService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}

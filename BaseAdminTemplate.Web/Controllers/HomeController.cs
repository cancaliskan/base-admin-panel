using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using BaseAdminTemplate.Business.Contracts;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
               IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper)
               : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult PermissionError()
        {
            return View();
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.Web.Models.ViewModels;

namespace BaseAdminTemplate.Web.Controllers
{
    [DisplayName(Constants.DisplayInMenu + "Hata Kayıtları")]
    public class ExceptionLogController : BaseController
    {
        public ExceptionLogController(IUserService userService, IPermissionService permissionService,
            IRoleService roleService, IMenuService menuService, IExceptionLogService exceptionLogService,
            IMapper mapper)
            : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
        {
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "Listele")]
        public IActionResult List()
        {
            if (!HasPermission("ExceptionLog", "List"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var response = ExceptionLogService.GetAll();
            if (response.IsSucceed)
            {
                var exceptionLogs = response.Result;
                var exceptionLogViewModel = Mapper.Map<IEnumerable<ExceptionLogViewModel>>(exceptionLogs.AsEnumerable());
                return View(exceptionLogViewModel);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public IActionResult DeleteAll()
        {
            var response = ExceptionLogService.DeleteAll();
            if (response.IsSucceed)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Error", "Home");
        }
    }
}
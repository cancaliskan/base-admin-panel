using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using AutoMapper;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.Web.Hubs;
using BaseAdminTemplate.Web.Models;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    [DisplayName(Constants.DisplayInMenu + "Role Management")]
    public class RoleController : BaseController
    {
        private readonly IHubContext<RoleHub> context;

        public RoleController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                              IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper,
                              IHubContext<RoleHub> context)
                              : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
        {
            this.context = context;
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + "List")]
        public IActionResult List()
        {
            var roles = GetRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult RefreshRoles()
        {
            var roles = GetRoles();
            return PartialView("_RoleData", roles);
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + "New")]
        public IActionResult Create()
        {
            var response = PermissionService.GetActivePermissions().Result;
            var permissions = Mapper.Map<IEnumerable<PermissionViewModel>>(response);
            var role = new RoleViewModel()
            {
                Permissions = permissions.ToList()
            };
            return View(role);
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel model)
        {
            var role = Mapper.Map<Role>(model);
            var response = RoleService.Create(role);
            if (response.IsSucceed)
            {
                context.Clients.All.SendAsync("refresh");
                return RedirectToAction("List");
            }

            ViewBag.ErrorMessage = response.ErrorMessage;
            return View(model);
        }

        private IEnumerable<RoleViewModel> GetRoles()
        {
            var response = RoleService.GetActiveRoles().Result;
            var roles = Mapper.Map<IEnumerable<RoleViewModel>>(response.AsEnumerable().ToList());
            return roles;
        }
    }
}
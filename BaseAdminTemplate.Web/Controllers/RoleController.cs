using System;
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
using BaseAdminTemplate.Web.Models.ViewModels;

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
            ViewBag.Permissions = GetPermissions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel model, List<string> permissions)
        {
            var role = Mapper.Map<Role>(model);
            var response = RoleService.Create(role);
            if (response.IsSucceed)
            {
                foreach (var permissionId in permissions)
                {
                    RoleService.AddPermissionToRole(response.Result.Id, new Guid(permissionId));
                }

                context.Clients.All.SendAsync("refresh");
                return RedirectToAction("List");
            }

            ViewBag.ErrorMessage = response.ErrorMessage;

            ViewBag.Permissions = GetPermissions();
            return View(model);
        }

        public IEnumerable<RoleViewModel> GetRoles()
        {
            var response = RoleService.GetActiveRoles().Result;
            var roles = Mapper.Map<IEnumerable<RoleViewModel>>(response.AsEnumerable().ToList());
            return roles;
        }

        public List<PermissionsModel> GetPermissions()
        {
            var permissions = new List<PermissionsModel>();
            var parentList = MenuService.GetActiveMenus().Result;
            foreach (var parent in parentList)
            {
                var childResult = MenuService.GetChildList(parent.Id).Result;
                var permission = new PermissionsModel()
                {
                    Id = parent.Id,
                    Name = parent.DisplayName,
                    ChildList = new List<Child>()
                };
                foreach (var child in childResult)
                {
                    var childItem = new Child() { Id = child.Id, Name = child.DisplayName, ParentId = parent.Id };
                    permission.ChildList.Add(childItem);
                }

                permissions.Add(permission);
            }

            return permissions;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

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
        private readonly IHubContext<RoleHub> _context;

        public RoleController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                              IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper,
                              IHubContext<RoleHub> context)
                              : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
        {
            _context = context;
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "List")]
        public IActionResult List()
        {
            if (!HasPermission("Role", "List"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var roles = GetRoles();
            return View(roles);
        }

        [HttpGet]
        public IActionResult RefreshData()
        {
            var roles = GetRoles();
            return PartialView("_RoleData", roles);
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "New")]
        public IActionResult Create()
        {
            if (!HasPermission("Role", "Create"))
            {
                return RedirectToAction("PermissionError", "Home");
            }
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

                _context.Clients.All.SendAsync("refresh");
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

        public IActionResult GetRolesWithUserId(string id)
        {
            var sb = new StringBuilder();
            var roles = RoleService.GetActiveRoles().Result;
            foreach (var role in roles)
            {
                sb.Append($"'{role.Id}':'{role.Name}',");
            }

            var selectedRoleId = UserService.GetRole(id.ToGuid()).Result.Id;

            sb.Append($"'selected': '{selectedRoleId}'");
            return Content("{" + sb.ToString() + "}");
        }

        public List<PermissionsModel> GetPermissions()
        {
            var permissions = new List<PermissionsModel>();
            var parentList = MenuService.GetActiveMenus().Result;
            foreach (var parent in parentList)
            {
                var childResult = MenuService.GetTreeChildList(parent.Id).Result;
                var permission = new PermissionsModel()
                {
                    Id = parent.Id,
                    Name = parent.DisplayName,
                    ChildList = new List<Child>()
                };

                var treeChild = childResult.Where(x => x.DisplayInPermissionTree);
                foreach (var child in treeChild)
                {
                    var childItem = new Child() { Id = child.Id, Name = child.DisplayName, ParentId = parent.Id };
                    permission.ChildList.Add(childItem);
                }

                permissions.Add(permission);
            }

            return permissions;
        }

        [HttpPost]
        [DisplayName("Delete")]
        public IActionResult Delete(string roleId)
        {
            if (!HasPermission("Role", "Delete"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var id = roleId.ToGuid();
            var response = RoleService.HardDelete(id);
            if (response.IsSucceed)
            {
                _context.Clients.All.SendAsync("refresh");
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInPermissionTree + "Edit")]
        public IActionResult Edit(string roleId)
        {
            if (!HasPermission("Role", "Edit"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var response = RoleService.GetById(roleId.ToGuid());
            if (response.IsSucceed)
            {
                var role = Mapper.Map<RoleViewModel>(response.Result);
                ViewBag.AllPermissions = GetPermissions();
                var rolePermissions = GetRolePermissions(roleId.ToGuid());
                ViewBag.RolePermissions = Mapper.Map<List<PermissionViewModel>>(rolePermissions);
                return View(role);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit(RoleViewModel model, List<string> permissions)
        {
            var role = Mapper.Map<Role>(model);
            var response = RoleService.Update(role);
            if (response.IsSucceed)
            {
                RoleService.RemoveAllPermissionFromRole(model.Id);
                foreach (var permissionId in permissions)
                {
                    RoleService.AddPermissionToRole(model.Id, permissionId.ToGuid());
                }

                _context.Clients.All.SendAsync("refresh");
                return RedirectToAction("List");
            }

            ViewBag.ErrorMessage = response.ErrorMessage;

            ViewBag.Permissions = GetPermissions();
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateField(string id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            var role = RoleService.GetById(id.ToGuid());
            if (role.IsSucceed)
            {
                object instance = role.Result;
                role.Result.GetType().GetProperty(propertyName)?.SetValue(instance, value);
                RoleService.Update(role.Result);
                _context.Clients.All.SendAsync("refresh");
                status = true;
            }
            else
            {
                message = "Error!";
            }

            var response = new { value = value, status = status, message = message };
            var o = JObject.FromObject(response);
            return Content(o.ToString());
        }
    }
}
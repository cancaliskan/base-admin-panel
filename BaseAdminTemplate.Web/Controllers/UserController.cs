using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json.Linq;
using AutoMapper;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.Web.Hubs;
using BaseAdminTemplate.Web.Models.ViewModels;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    [DisplayName(Constants.DisplayInMenu + "User Management")]
    public class UserController : BaseController
    {
        private readonly IHubContext<UserHub> _context;

        public UserController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                              IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper)
                              : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
        {
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "List")]
        public IActionResult List()
        {
            if (!HasPermission("User", "List"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var roles = GetUsers();
            return View(roles);
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            var response = UserService.GetActiveUsers().Result;
            var users = Mapper.Map<IEnumerable<UserViewModel>>(response.AsEnumerable().ToList());
            return users;
        }

        [HttpGet]
        public IActionResult RefreshData()
        {
            var users = GetUsers();
            return PartialView("_UserData", users);
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
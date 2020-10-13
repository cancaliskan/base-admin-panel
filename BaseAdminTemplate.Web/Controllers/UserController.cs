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
using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.Web.Hubs;
using BaseAdminTemplate.Web.Models.ViewModels;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    [DisplayName(Constants.DisplayInMenu + "Kullanıcı Yönetimi")]
    public class UserController : BaseController
    {
        private readonly IHubContext<UserHub> _context;

        public UserController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                              IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper,
                              IHubContext<UserHub> context)
                              : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
        {
            _context = context;
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "Aktif Kullanıcı Listesi")]
        public IActionResult ActiveList()
        {
            if (!HasPermission("User", "ActiveList"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var users = GetActiveUsers();
            return View(users);
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "Deaktif Kullanıcı Listesi")]
        public IActionResult DeactivatedList()
        {
            if (!HasPermission("User", "DeactivatedList"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var users = GetDeactivatedUsers();
            return View(users);
        }

        public IEnumerable<UserViewModel> GetActiveUsers()
        {
            var response = UserService.GetActiveUsers().Result;
            var users = Mapper.Map<IEnumerable<UserViewModel>>(response.AsEnumerable().ToList());
            foreach (var user in users)
            {
                var result = UserService.GetRole(user.Id);
                if (result.IsSucceed)
                {
                    user.Role = Mapper.Map<RoleViewModel>(result.Result);
                }
            }

            return users;
        }

        public IEnumerable<UserViewModel> GetDeactivatedUsers()
        {
            var response = UserService.GetInActiveUsers().Result;
            var users = Mapper.Map<IEnumerable<UserViewModel>>(response.AsEnumerable().ToList());
            foreach (var user in users)
            {
                var result = UserService.GetRole(user.Id);
                if (result.IsSucceed)
                {
                    user.Role = Mapper.Map<RoleViewModel>(result.Result);
                }
            }

            return users;
        }

        [HttpGet]
        public IActionResult RefreshActiveUserData()
        {
            var users = GetActiveUsers();
            return PartialView("_ActiveUserData", users);
        }

        [HttpGet]
        public IActionResult RefreshDeactivatedUserData()
        {
            var users = GetDeactivatedUsers();
            return PartialView("_DeactivatedUserData", users);
        }

        [HttpPost]
        [DisplayName(Constants.DisplayInPermissionTree + "Güncelle")]
        public IActionResult Edit(string id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            if (!HasPermission("User", "Edit"))
            {
                message = "Yetkiniz bulunmuyor";
            }
            else
            {
                var serviceResponse = UserService.GetById(id.ToGuid());
                if (serviceResponse.IsSucceed)
                {
                    if (propertyName.Equals("Role"))
                    {
                        UserService.UpdateRole(serviceResponse.Result.Id, value.ToGuid());
                        _context.Clients.All.SendAsync("refresh");
                        status = true;
                    }
                    else
                    {
                        object instance = serviceResponse.Result;
                        serviceResponse.Result.GetType().GetProperty(propertyName)?.SetValue(instance, value);
                        var result = UserService.Update(serviceResponse.Result);
                        if (result.IsSucceed)
                        {
                            _context.Clients.All.SendAsync("refresh");
                            status = true;
                        }
                        else
                        {
                            message = result.ErrorMessage;
                        }
                    }
                }
                else
                {
                    message = serviceResponse.ErrorMessage;
                }
            }

            var response = new { value = value, status = status, message = message };
            var o = JObject.FromObject(response);
            return Content(o.ToString());
        }

        [HttpPost]
        [DisplayName(Constants.DisplayInPermissionTree + "Deaktif Yap")]
        public IActionResult Deactivate(string userId)
        {
            if (!HasPermission("User", "Deactivate"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var response = UserService.SoftDelete(userId.ToGuid());
            if (response.IsSucceed)
            {
                _context.Clients.All.SendAsync("refresh");
                return RedirectToAction("ActiveList");
            }

            return RedirectToAction("ActiveList");
        }

        [HttpPost]
        [DisplayName(Constants.DisplayInPermissionTree + "Kurtar")]
        public IActionResult Restore(string userId)
        {
            if (!HasPermission("User", "Restore"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var response = UserService.Restore(userId.ToGuid());
            if (response.IsSucceed)
            {
                _context.Clients.All.SendAsync("refresh");
                return RedirectToAction("DeactivatedList");
            }

            return RedirectToAction("DeactivatedList");
        }

        [HttpGet]
        [DisplayName(Constants.DisplayInMenu + Constants.DisplayInPermissionTree + "Ekle")]
        public IActionResult Create()
        {
            if (!HasPermission("User", "Create"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            ViewBag.Roles = Mapper.Map<IEnumerable<RoleViewModel>>(RoleService.GetActiveRoles().Result.AsEnumerable());
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel model, string roleId)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Parola ve parola onayı uyuşmuyor";
                return View(model);
            }

            var user = Mapper.Map<User>(model);
            var response = UserService.Create(user);
            if (response.IsSucceed)
            {
                UserService.AddRoleToUser(response.Result.Id, roleId.ToGuid());

                _context.Clients.All.SendAsync("refresh");
                return RedirectToAction("ActiveList");
            }

            ViewBag.ErrorMessage = response.ErrorMessage;
            ViewBag.Roles = Mapper.Map<IEnumerable<RoleViewModel>>(RoleService.GetActiveRoles().Result.AsEnumerable());
            return View(model);
        }

        [HttpPost]
        [DisplayName("Sil")]
        public IActionResult Delete(string userId)
        {
            if (!HasPermission("User", "Delete"))
            {
                return RedirectToAction("PermissionError", "Home");
            }

            var id = userId.ToGuid();
            var response = UserService.HardDelete(id);
            if (response.IsSucceed)
            {
                _context.Clients.All.SendAsync("refresh");
                return RedirectToAction("ActiveList");
            }

            return RedirectToAction("ActiveList");
        }
    }
}
﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.Web.Models;
using BaseAdminTemplate.Web.Models.ViewModels;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUserService UserService;
        protected readonly IPermissionService PermissionService;
        protected readonly IRoleService RoleService;
        protected readonly IExceptionLogService ExceptionLogService;
        protected readonly IMenuService MenuService;

        protected readonly IMapper Mapper;

        public BaseController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                              IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper)
        {
            UserService = userService;
            PermissionService = permissionService;
            RoleService = roleService;
            ExceptionLogService = exceptionLogService;
            MenuService = menuService;
            Mapper = mapper;
        }

        public MenuItemsModel GetMenuItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId.IsEmpty())
            {
                return null;
            }

            var role = UserService.GetRole(new Guid(userId)).Result;
            var parentMenuList = new List<MenuViewModel>();
            var subMenuList = RoleService.GetPermissions(role.Id).Result;
            foreach (var subMenu in subMenuList)
            {
                var parentMenu = PermissionService.GetParent(subMenu.Id).Result;
                if (parentMenuList.FirstOrDefault(x => x.Id == parentMenu.Id) == null)
                {
                    var menuViewModel = Mapper.Map<MenuViewModel>(parentMenu);
                    parentMenuList.Add(menuViewModel);
                }
            }

            var parentItemList = new List<ControllerItemsModel>();
            foreach (var parentMenu in parentMenuList)
            {
                var methods = new List<MethodsItemsModel>();
                var childList = MenuService.GetChildList(parentMenu.Id).Result;
                foreach (var child in childList)
                {
                    if (subMenuList.Any(x => x.Id == child.Id))
                    {
                        methods.Add(new MethodsItemsModel()
                        {
                            MethodName = child.MethodName,
                            DisplayName = child.DisplayName
                        });
                    }
                }

                parentItemList.Add(new ControllerItemsModel()
                {
                    ControllerName = parentMenu.ControllerName,
                    DisplayName = parentMenu.DisplayName,
                    Methods = methods
                });
            }

            var menu = new MenuItemsModel()
            {
                MenuItems = parentItemList
            };

            return menu;
        }

        public bool HasPermission(string controllerName, string methodName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId.IsEmpty())
            {
                return true;
            }

            var role = UserService.GetRole(new Guid(userId)).Result;
            var permissions = RoleService.GetPermissions(role.Id).Result;
            var hasPermission = false;
            foreach (var permission in permissions)
            {
                var parent = PermissionService.GetParent(permission.Id).Result;
                if (parent.ControllerName == controllerName
                    && permission.MethodName == methodName)
                {
                    hasPermission = true;
                }
            }

            return hasPermission;
        }
    }
}
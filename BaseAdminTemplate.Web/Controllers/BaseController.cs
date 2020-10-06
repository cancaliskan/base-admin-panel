using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.Web.Models;

namespace BaseAdminTemplate.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUserService UserService;
        protected readonly IPermissionService PermissionService;
        protected readonly IRoleService RoleService;
        protected readonly IExceptionLogService ExceptionLogService;
        protected readonly IMenuService MenuService;

        public BaseController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                              IMenuService menuService, IExceptionLogService exceptionLogService)
        {
            UserService = userService;
            PermissionService = permissionService;
            RoleService = roleService;
            ExceptionLogService = exceptionLogService;
            MenuService = menuService;
        }

        public MenuItemsModel GetMenuItems()
        {
            var parentMenuList = new List<Menu>();
            var subMenuList = PermissionService.GetAll().Result;
            foreach (var subMenu in subMenuList)
            {
                var parentMenu = PermissionService.GetParent(subMenu.Id).Result;
                if (parentMenuList.FirstOrDefault(x => x.Id == parentMenu.Id) == null)
                {
                    parentMenuList.Add(parentMenu);
                }
            }

            var parentItemList = new List<ControllerItemsModel>();
            foreach (var parentMenu in parentMenuList)
            {
                var methods = new List<MethodsItemsModel>();
                var childList = MenuService.GetChildList(parentMenu.Id).Result;
                foreach (var child in childList)
                {
                    methods.Add(new MethodsItemsModel()
                    {
                        MethodName =child.MethodName,
                        DisplayName = child.DisplayName
                    });
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
    }
}
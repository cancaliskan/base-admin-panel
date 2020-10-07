using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Web.Models;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                                 IMenuService menuService, IExceptionLogService exceptionLogService)
                               : base(userService, permissionService, roleService, menuService, exceptionLogService)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var response = UserService.Login(model.Email, model.Password);
            if (response.IsSucceed)
            {
                var userClaims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, response.Result.Name),
                    new Claim(ClaimTypes.Email, response.Result.Email)
                };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = response.ErrorMessage;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
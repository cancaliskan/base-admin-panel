using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

using AutoMapper;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.Domain.Entities;
using BaseAdminTemplate.Web.Models.ViewModels;

namespace BaseAdminTemplate.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(IUserService userService, IPermissionService permissionService, IRoleService roleService,
                                 IMenuService menuService, IExceptionLogService exceptionLogService, IMapper mapper)
                                 : base(userService, permissionService, roleService, menuService, exceptionLogService, mapper)
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
                    new Claim(ClaimTypes.NameIdentifier, response.Result.Id.ToString()),
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

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (model.NewPassword != model.NewPasswordConfirm)
            {
                ViewBag.ErrorMessage = "new password and new password confirm are not equal";
                return View();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = UserService.ChangePassword(userId.ToGuid(), model.OldPassword, model.NewPassword);
            if (response.IsSucceed)
            {
                ViewBag.SuccessMessage = response.SuccessMessage;
                return View();
            }

            ViewBag.ErrorMessage = response.ErrorMessage;
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = UserService.GetById(userId.ToGuid());
            if (response.IsSucceed)
            {
                var user = response.Result;
                var userViewModel = Mapper.Map<UserViewModel>(user);
                return View(userViewModel);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            var user = Mapper.Map<User>(model);
            var response = UserService.Update(user);
            if (response.IsSucceed)
            {
                ViewBag.SuccessMessage = response.SuccessMessage;
                return View(model);
            }

            ViewBag.ErrorMessage = response.ErrorMessage;
            return View(model);
        }
    }
}
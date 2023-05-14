using API.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Interfaces;
using BLL.Models;
using BLL.Interfaces;
using BLL.Helpers;

namespace API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) {

            _userService = userService;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.Login(_User(model));
                if (response.StatusCode == BLL.Helpers.StatusCode.OK) {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterModel model)
        {
           
            if (ModelState.IsValid) { 
            var response = await _userService.Register(_User(model));
            if (response.StatusCode == BLL.Helpers.StatusCode.OK) {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", response.Description);
        } 
            return View(model);
        }


       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        public  UserModel _User(RegisterModel registerModel) {
            var User = new UserModel
            {
                Email = registerModel.Email,
                Password = registerModel.Password,
            };
            return User;
        }
        public UserModel _User(LoginModel loginModel) {
            var User = new UserModel
            {
                Email = loginModel.Email,
                Password = loginModel.Password,
            };
            return User;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MtgCollectionMgr.Models;
using MtgCollectionMgr.ViewModels;

namespace MtgCollectionMgr.Controllers
{
    [Route("Account/[action]")]
    public class UserController : Controller
    {
        private readonly MtgCollectionMgrContext _context;

        public UserController(MtgCollectionMgrContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel, string returnUrl = null)
        {
            if(AuthenticateUser(userModel.Username, userModel.Password))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userModel.Username),
                    new Claim(ClaimTypes.Role, "user")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return Redirect("/CollectionModels/ViewCollection");
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var newUser = new UserModel(viewModel.Username, viewModel.Password);
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return Redirect("/CollectionModels/ViewCollection");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        private bool AuthenticateUser(string username, string password)
        {
            return true;
        }
    }
}
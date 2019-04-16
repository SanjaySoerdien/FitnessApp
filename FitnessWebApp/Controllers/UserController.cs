using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([Bind("Password, Username")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            user = LoginUser(user);
            if (user != null)
            {
                return RedirectToAction("Index", "Home"); //redirect naar page om cookies te refreshen
            }
            return View("Login");
        }

        public IActionResult Logout()
        {
            this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            User user = new User();
            UserLogic userLogic = new UserLogic();
            user = userLogic.GetUserInfo(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public IActionResult AddUser([Bind("Password, Username, Nickname")] User user)
        {
            UserLogic userlogic = new UserLogic();
            userlogic.AddUser(user);
            LoginUser(user);
            return RedirectToAction("Index", "Home");
        }

        private User LoginUser(User user)
        {
            UserLogic userLogic = new UserLogic();
            var claims = new List<Claim>();
            user = userLogic.Login(user.Username, user.Password);
            if (user != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.Nickname));
                ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                var authProp = new AuthenticationProperties { IsPersistent = true };
                this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProp);
            }
            return user;
        }
    }
}
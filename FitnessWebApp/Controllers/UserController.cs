using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessWebApp.Models;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class UserController : Controller
    {
        UserLogic userLogic = new UserLogic();
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([Bind("Password, Username")] User user)
        {
            if (!ModelState.ContainsKey("Password")&& !ModelState.ContainsKey("Username"))
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

        public IActionResult Register([Bind("Password, Username, Nickname, Confirm Password")] RegisterViewModel user)
        {
            if (!ModelState.IsValid && user.Password == user.ConfirmPassword)
            {
                return View();
            }
            User userToAdd = new User
            {
                Nickname = user.Nickname,
                Password = user.Password,
                Role = "Member"
            };
            userLogic.AddUser(userToAdd);
            AuthorizeUser(userToAdd);
            return RedirectToAction("Index", "Home"); //redirect naar page om cookies te refreshen

        }

        public IActionResult Profile(string nickname)
        {
            User user = new User();
            user = userLogic.GetUserInfo(nickname);
            return View(user);
        }

        [HttpPost]
        public IActionResult AddUser([Bind("Password, Username, Nickname")] User user)
        {
            userLogic.AddUser(user);
            LoginUser(user);
            return RedirectToAction("Index", "Home");
        }

        private User LoginUser(User user)
        {
            user = userLogic.Login(user.Username, user.Password);
            if (user != null)
            {
                AuthorizeUser(user);
            }
            return user;
        }

        private void AuthorizeUser(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
            claims.Add(new Claim(ClaimTypes.Name, user.Nickname));
            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            var authProp = new AuthenticationProperties { IsPersistent = true };
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProp);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
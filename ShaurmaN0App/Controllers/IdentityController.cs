using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShaurmaN0App.Dtos;

namespace ShaurmaN0App.Controllers
{
    [Route("/[controller]/[action]")]

    public class IdentityController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [ActionName("Register")]
        public IActionResult Register() => View();

        [HttpPost]
        [ActionName("RegisterApi")]
        public async Task<IActionResult> Register(RegisterDto regi)
        {
            var email = regi.Email;
            var password = regi.Password;

            if (ModelState.IsValid == false)
            {
                return View("Register", regi);
            }


            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            Console.WriteLine($"User creation result: {result.Succeeded}");
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }


            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }
            return View("Register", regi);
        }

        [HttpGet]
        [ActionName("Login")]
        public IActionResult Login() => View();

        [HttpPost]
        [ActionName("LoginApi")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var email = loginDto.Email;
            var password = loginDto.Password;

            if (ModelState.IsValid == false)
            {
                ModelState.AddModelError("", "Email and password are required.");
                return View("Login", loginDto);
            }

            var result = await _signInManager.PasswordSignInAsync(email, password, true, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Incorrect login or password");
            return View("Login", loginDto);
        }

        [HttpGet]
        [ActionName("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName("AccessDenied")]
        public IActionResult AccessDenied() => View();
    }
}
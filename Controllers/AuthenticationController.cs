using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyStatz.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignIn(string signinProvider = "Steam")
        {          
            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            //var providers = HttpContext.RequestServices.GetService(typeof(IAuthenticationSchemeProvider));
            return Challenge(new AuthenticationProperties { RedirectUri = "/Home/MyProfile" }, signinProvider);
        }        
        
        [HttpPost]
        public async Task<IActionResult> SignOut()//[FromForm] string provider)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/"); /*Challenge(new AuthenticationProperties { RedirectUri = "/Home/MyProfile" }, "Steam");*/
        }
    }
}
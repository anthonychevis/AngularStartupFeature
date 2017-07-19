using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kit.Feature.Account
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult External(string provider)
        {
            return new ChallengeResult(provider, new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties() {
                RedirectUri =  "/home/index"
            });
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");

            return RedirectToAction(nameof(Login));
        }
    }
}

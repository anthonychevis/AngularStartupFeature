using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace Kit.Feature.Home
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            Log.Logger.Information( nameof(HomeController) + " : {@Now}, Tuple: {@Tuple} ", DateTime.Now, Tuple.Create("Hello", 1));
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

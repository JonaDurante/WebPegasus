using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Pegasus.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Pegasus.Web.Helpers;

namespace Pegasus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var a = User.GetUserId();

            //hacer método
            ViewBag.claims = User.Claims;
            ViewBag.User = User.Identity.Name;
            //User.Identity.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

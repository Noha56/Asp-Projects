using Microsoft.AspNetCore.Mvc;
using Midterm.Models;
using System.Diagnostics;

namespace Midterm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/home/index/99")]
        public IActionResult Index()
        {   
            return View();
        }
        [Route("")]
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Byby()
        {
            return PartialView("GoodLuck");
        }
    }
}
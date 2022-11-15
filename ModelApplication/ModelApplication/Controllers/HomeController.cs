using Microsoft.AspNetCore.Mvc;
using ModelApplication.Models;
using System.Diagnostics;

namespace ModelApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
         
        public IActionResult Index()
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
        public ActionResult CreateStudent()
        {
            Student student = new Student()
            {
                Id="201910805",
                Dept="CS"
            };
            student.Name = "Noha";

            return View(student);
        }
        public ActionResult CreateEmployee()
        {
            Employee emp = new Employee()
            {   Name="Noha",
                Id = 1,
                Salary = 5000,
            };
            String name = emp?.Name??"No name!!";
            int ?x = emp?.Id??0;

            return View(emp);
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace FormApplication.Controllers
{
    public class ActionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VBAction(string txtUser, string txtId, string txtDept)
        {
            ViewBag.name=txtUser;
            ViewBag.id=txtId;   
            ViewBag.dept=txtDept;

            return View();
        }
        [HttpPost]
        public ActionResult FormAction(IFormCollection form)
        {
            ViewBag.name = form["txtUser"];
            ViewBag.id = form["txtID"];
            ViewBag.dept = form["txtDept"];

            return View();
        }
        public ActionResult RequestAction()
        {
            ViewBag.name = Request.Form["txtUser"];
            ViewBag.id = Request.Form["txtID"];
            ViewBag.dept = Request.Form["txtDept"];

            return View();
        }
        [HttpPost]
        public ActionResult Login(IFormCollection form)
        { 
            if(form["txtUser"]=="Admin1"&& form["txtPass"]=="123456")

            return Content("Correct");

            return Content("Incorrect");
        }
    }
}

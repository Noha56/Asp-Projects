using Microsoft.AspNetCore.Mvc;

namespace ParametersApllication.Controllers
{
    public class CallActions : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public String Action0Param()
        {
            return ("No Values");
        }
        public String Action1Param(int id)
        {
            return ("My ID "+id);
        }
        public String Action2Param(int id,String name)
        {
            return ("My ID "+id+" My Name is: "+name);
        } 
        public ActionResult Action3Param(int id,String name,String dept)
        {
            ViewBag.id = id;
            ViewBag.name= name;
            ViewBag.dept= dept;
            return View();
        }
    }
}

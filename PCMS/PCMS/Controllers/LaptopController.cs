using Microsoft.AspNetCore.Mvc;
using PCMS.Models;

namespace PCMS.Controllers
{
    public class LaptopController : Controller
    {
        public static List<Laptop> laptops = new List<Laptop>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddLaptop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLaptop(Laptop laptop)
        {
            
            laptops.Add(laptop);
            ModelState.Clear();
            return View();
        }
        public IActionResult DisplayList()
        {
            return View(laptops);
        }
        public IActionResult Details(int id)
        {
            Laptop lap = laptops.Where(x => x.Id == id).FirstOrDefault();
            return View(lap);
        }
       
        public IActionResult Edit(Laptop laptop)
        {
          
            return View();
        }

   
        public IActionResult Delete(int id)
        {
            Laptop r = laptops.Where(i => i.Id == id).FirstOrDefault();
            laptops.Remove(r);
            return View(r);
        }

    }
}

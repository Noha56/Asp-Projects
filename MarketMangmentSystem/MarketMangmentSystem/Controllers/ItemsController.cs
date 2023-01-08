using MarketMangmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketMangmentSystem.Controllers
{
    public class ItemsController : Controller
    {
        public static List<Item> _items = new List<Item>();
        public IActionResult Index()
        {
            return View(_items);
        }
        [HttpGet]
        public ActionResult AddItme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddItme(Item item)
        {
            _items.Add(item);
            ModelState.Clear();
            return View("Index", _items);
        }

        [HttpGet]
        public ActionResult Search()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Search(Item item)
        {
            
           List<Item>r=_items.Where(s => s.Barcode == item.Barcode).ToList();
            return View("index",r);
        }
    }
}

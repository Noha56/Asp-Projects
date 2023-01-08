using MarketMangmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketMangmentSystem.Controllers
{
    public class ItemsController : Controller
    {
        public static List<Item> _items = new List<Item>();
        public IWebHostEnvironment _webHostEnvironment;
        public ItemsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
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
            if (item.ImageFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + item.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                     item.ImageFile.CopyToAsync(fileStream);
                }
                item.ImagePath = fileName;

            }


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
            List<Item> r = _items.Where(s => s.Barcode == item.Barcode).ToList();
            //List<Item> r = _items.Where(s => s.Price == item.Price).ToList();
            return View("index", r);
        }
    

        [HttpPost]
        public ActionResult Search2(Item item)
        {
            //List<Item> r = _items.Where(s => s.Barcode == item.Barcode).ToList();
            List<Item> r = _items.Where(s => s.Price == item.Price).ToList();
            return View("index", r);
        }
        [HttpPost]
        public ActionResult Search3(Item item)
        {
           
            List<Item> r = _items.Where(s =>s.Desc!.Contains(item.Desc!)).ToList();
            return View("index", r);
        }
        //[HttpPost]
        //public ActionResult Search(IFormCollection form)
        //{
        //    int barcode = int.Parse(form["Barcode"]);
        //    List<Item> result_items = new List<Item>();
        //    foreach(var i in _items)
        //    {
        //        if(i.Barcode == barcode)
        //        {
        //            result_items.Add(i);
        //        }
        //    }

        //    return View("Index",result_items);
        //}

        [HttpGet]
        public ActionResult Edit()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Edit(IFormCollection form)
        {
            int barcode = int.Parse(form["Barcode"]);
            Item r = _items.Where(s => s.Barcode == barcode).First();
            return View("Dispaly", r);
        }
        public IActionResult Dispaly()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {
            Item r = _items.Where(s => s.Desc == item.Desc).FirstOrDefault();
            _items.Remove(item);
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace AttributeRountingApp.Controllers
{
    public class ProductsController : Controller
    {
        [Route("")]
        [Route("Products")]
        [Route("Product")]

        public IActionResult Index()
        {
            return View();
        }
        [Route("AT")]
        [Route("/Products/at")]
        [Route("/product/at")]
        [Route("/pd/at")]

        public ActionResult AttributAction()
        {
            return View();
        }
        [Route("pd/(id)/(desc)")]
        // [Route("pd/(desc)/(id)")]-->error
        [Route("/{id}/{desc}")]
        public ActionResult ProductDetails(int id, string desc)
        {
            ViewBag.id = id;
            ViewBag.desc = desc;
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    
    public class ProductsController : Controller
    {
        HttpClientHandler handler=new HttpClientHandler();
        Product product = new Product();
        List<Product> products = new List<Product>();   

        public ProductsController()
        {
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            products = new List<Product>();
            using(var httpClient = new HttpClient())
            {
                using (var response =await httpClient.GetAsync("https://localhost:7254/api/Products"))
                {
                    String apiResponse=await response.Content.ReadAsStringAsync();

                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }

            return View("DisplayProducts", products);
        }
        public async Task<ActionResult> GetProductById(int id)
        {
            product = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7254/api/Products/"+id))
                {
                    String apiResponse = await response.Content.ReadAsStringAsync();

                    product = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }

            return View("Details", product);
        }
        public ActionResult Details(Product product)
        {

            return View(product);
        }
        public ActionResult DisplayProducts()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

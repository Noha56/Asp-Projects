using Microsoft.AspNetCore.Mvc;

namespace UrlRountingApp.Controllers
{
    public class Page1Controller : Controller
    {
       
        //[Route("")]
        public String Action1()
        {
            return "Action 1 in Page 1";
        }
        public String Action2()
        {
            return "Action 2 in Page 1";
        }
    }
}

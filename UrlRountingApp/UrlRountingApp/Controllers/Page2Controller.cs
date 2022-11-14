using Microsoft.AspNetCore.Mvc;

namespace UrlRountingApp.Controllers
{
    public class Page2Controller : Controller
    {
       
        public String Action1()
        {
            return "Action 1 in Page 2";
        }
        public String Action2()
        {
            return "Action 2 in Page 2";
        }
    }
}

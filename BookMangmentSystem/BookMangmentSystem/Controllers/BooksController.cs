using BookMangmentSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMangmentSystem.Controllers
{
    public class BooksController : Controller
    {
        static List<Book> book_list = new List<Book>();//create once
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult CreateBooks()
        {  
            book_list.Add(new Book { BTitle = "C#", ISBN = 1234, Price = 10.5f });
            book_list.Add(new Book { BTitle = "Java", ISBN = 5678, Price = 20.5f });
            book_list.Add(new Book { BTitle = "Python", ISBN = 91011, Price = 15.5f });

            return View(book_list);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(IFormCollection form)
        {
            book_list.Add(new Book { BTitle = form["btitle"], ISBN = int.Parse(form["isbn"]), Price = float.Parse(form["price"]) });


            return View("createbooks", book_list);
        }
    }
}

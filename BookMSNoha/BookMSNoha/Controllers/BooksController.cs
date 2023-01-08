using BookMSNoha.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMSNoha.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> ListOfBooks = new List<Book>();
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
 
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                ListOfBooks.Add(book);
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult DisplayBooks()
        {
            return View(ListOfBooks);
        }
        public ActionResult Details(int id)
        {
            Book book = ListOfBooks.Where(x => x.BookId == id).FirstOrDefault()!;
            return View(book);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book book = ListOfBooks.Where(x => x.BookId == id).FirstOrDefault()!;
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book_before)
        {
            Book book_afterEdit = ListOfBooks.Where(x => x.BookId == book_before.BookId).FirstOrDefault()!;


            if (ModelState.IsValid)
            
            {

                book_afterEdit.BookTitle = book_before.BookTitle;
                book_afterEdit.AuthorName = book_before.AuthorName;
                book_afterEdit.PublisherName = book_before.PublisherName;
                book_afterEdit.SerialNumber = book_before.SerialNumber;
            }

            return View("DisplayBooks", ListOfBooks);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book book = ListOfBooks.Where(x => x.BookId == id).FirstOrDefault()!;
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(Book book)
        {
            Book book_toRemove = ListOfBooks.Where(x => x.BookId == book.BookId).FirstOrDefault()!;
            ListOfBooks.Remove(book_toRemove);
            return View("DisplayBooks", ListOfBooks);
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchById(Book book)
        {
            List<Book> result = new List<Book>();

            result = ListOfBooks.Where(s => s.BookId == book.BookId).ToList();
            return View("ViewBooks", result);
        }
        [HttpPost]
        public ActionResult SearchByTitle(Book book)
        {
            List<Book> result = new List<Book>();
            result = ListOfBooks.Where(s => s.BookTitle.Equals(book.BookTitle)).ToList();
            return View("ViewBooks", result);
        }
        [HttpPost]
        public ActionResult SearchBySerialNumber(Book book)
        {
            List<Book> result = new List<Book>();
            result = ListOfBooks.Where(s => s.SerialNumber.Equals(book.SerialNumber)).ToList();
            return View("ViewBooks", result);
        }
        [HttpPost]
        public ActionResult SearchByAuthor(Book book)
        {
            List<Book> result = new List<Book>();
            result = ListOfBooks.Where(s => s.AuthorName.Equals(book.AuthorName)).ToList();
            return View("ViewBooks", result);
        }
        [HttpPost]
        public ActionResult SearchByPublisher(Book book)
        {
            List<Book> result = new List<Book>();
            result = ListOfBooks.Where(s => s.PublisherName.Equals(book.PublisherName)).ToList();
            return View("ViewBooks", result);
        }

        public ActionResult ViewBooks()
        {
            return View();
        }

    }
}

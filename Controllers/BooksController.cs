using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthorsBooksApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService = new BookService();

        public async Task<ActionResult> Index()
        {
            var books = await _bookService.GetAllBooks();
            return View(books);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            ViewBag.Message = "";
            var bookInserted = await _bookService.AddBook(book);
            if (bookInserted != null)
            {
                ViewBag.Message = "Book added successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error adding book.";
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Book book)
        {
            ViewBag.Message = "";
            var bookUpdated = await _bookService.UpdateBook( book);

            if (bookUpdated != null)
            { 
                ViewBag.Message = "Book updated successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Error updating book.";
                return View();
            }
        }
    }
}
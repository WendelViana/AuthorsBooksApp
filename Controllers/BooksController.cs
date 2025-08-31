using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services;
using AuthorsBooksApp.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthorsBooksApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

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

        [HttpGet]
        public ActionResult Edit(string id) 
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return View(book);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<ActionResult> Update(Book book)
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
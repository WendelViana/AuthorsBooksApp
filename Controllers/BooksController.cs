using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services.Interfaces;
using System;
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
            try
            {
                var books = await _bookService.GetAllBooks();
                return View(books);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error loading books.";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                var bookInserted = await _bookService.AddBook(book);
                if (bookInserted != null)
                {
                    TempData["Message"] = "Book added successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error adding book.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error adding book.";
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            try
            {
                var book = await _bookService.GetBookById(id);

                if (book != null)
                {
                    return View(book);
                }

                TempData["Error"] = "Book not found.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error loading book.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(Book book)
        {
            try
            {
                var bookUpdated = await _bookService.UpdateBook(book);
                if (bookUpdated != null)
                {
                    TempData["Message"] = "Book updated successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error updating book.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error updating book.";
                return View();
            }
        }
    }
}
using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services;
using AuthorsBooksApp.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthorsBooksApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<ActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthors();
            return View(authors);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var inserted = await _authorService.AddAuthor(author);

                    if (inserted != null)
                    {
                        TempData["Message"] = "Author added successfully.";

                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login process. {ex.Message}");
                //Add logging here
            }

            TempData["Error"] = "Author not added.";

            return View(author);

        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id) 
        {
            var author = await _authorService.GetById(id);

            if (author != null)
            {
                return View(author);
            }

            TempData["Error"] = "Author not found.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Author author)
        {

            if (ModelState.IsValid)
            {
                await _authorService.UpdateAuthor(author);
                TempData["Message"] = "Author updated successfully.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Author not updated.";

            return View(author);
        }
    }
}
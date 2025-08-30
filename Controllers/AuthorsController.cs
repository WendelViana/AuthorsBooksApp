using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthorsBooksApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorService _authorService = new AuthorService();


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
            if (ModelState.IsValid)
            {
                await _authorService.AddAuthor(author);
                TempData["Message"] = "Author added successfully.";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Author not added.";

            return View(author);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Author author)
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
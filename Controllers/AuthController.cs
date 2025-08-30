using AuthorsBooksApp.Helpers;
using AuthorsBooksApp.Models;
using AuthorsBooksApp.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AuthorsBooksApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService = new AuthService();

        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            var user = await _authService.GetUserByEmail(email);

            if (user != null && PasswordHelper.IsPasswordValid(password, user.PasswordHash))
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid login.";
            return View();
        }

        [HttpGet]
        public ActionResult Register() => View();

        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            var registered = await _authService.RegisterUser(user);

            if (registered != null)
            {
                return RedirectToAction("RegisterConfirmation");
            }   

            ViewBag.Error = "Registration failed.";
            return View();
        }

        public ActionResult RegisterConfirmation() => View();

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MoneyFlow.Managers;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager _userManager;

        public AccountController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewModel = new LoginVM();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var found = _userManager.Login(viewModel);

            if (found == null)
            {
                ViewBag.Message = "No matches found";
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var viewModel = new UserVM();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(UserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Por favor, completá bien los campos.";
                ViewBag.Class = "alert-danger";
                return View(viewModel);
            }

            try
            {
                var response = _userManager.Register(viewModel);
                if (response != 0)
                {
                    ViewBag.Message = "Your account has been registered successfully";
                    ViewBag.Class = "alert-success";
                }
                else
                {
                    ViewBag.Message = "Your account could not be registered";
                    ViewBag.Class = "alert-danger";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Class = "alert-danger";
            }

            return View(viewModel);
        }
    }
}
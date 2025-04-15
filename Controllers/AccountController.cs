using COLLEGE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace COLLEGE.Controllers
{
    public class AccountController : Controller
    {
        private const string AdminEmail = "admin111@gmail.com";
        private const string AdminPassword = "admin123";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Email == AdminEmail && model.Password == AdminPassword)
            {
                HttpContext.Session.SetString("IsAdmin", "true");

                // Get return URL if any
                string returnUrl = HttpContext.Session.GetString("ReturnUrl");
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    HttpContext.Session.Remove("ReturnUrl");
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Student"); // fallback
            }

            ModelState.AddModelError("", "Invalid credentials.");
            return View(model);
        }

    }
}

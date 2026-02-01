using Microsoft.AspNetCore.Mvc;

namespace Single_Device_Attendance_Recorder.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            TempData["Message"] = "Account created successfully!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "test" && password == "1234")
                return RedirectToAction("Welcome", "Home");

            ViewBag.Error = "Invalid login";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            TempData["Message"] = "You have been logged out.";
            return RedirectToAction("Index", "Home");
        }
    }
}
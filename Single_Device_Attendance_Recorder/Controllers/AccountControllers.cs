using Microsoft.AspNetCore.Mvc;
using Single_Device_Attendance_Recorder.Models;
using System.Linq;

namespace Single_Device_Attendance_Recorder.Controllers
{
    public class AccountController : Controller
    {
        private readonly AttendanceDbContext _context;
        public AccountController(AttendanceDbContext context)
        {
            _context = context;
        }

        // Register page
        [HttpGet]
        public IActionResult Register() => View();

        // Register new user
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Username and password are required.";
                return View();
            }

            // Checker if username already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                ViewBag.Error = "Username already taken.";
                return View();
            }

            // Save a new user
            var user = new User { Username = username, Password = password };
            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["Message"] = "Account created successfully!";
            return RedirectToAction("Login");
        }

        // Login page
        [HttpGet]
        public IActionResult Login() => View();

        // Login user
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                TempData["Message"] = $"Welcome, {user.Username}!";
                return RedirectToAction("Welcome", "Home");
            }

            ViewBag.Error = "Invalid login credentials.";
            return View();
        }

        // Logout
        [HttpGet]
        public IActionResult Logout()
        {
            TempData["Message"] = "You have been logged out.";
            return RedirectToAction("Index", "Home");
        }
    }
}
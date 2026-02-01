using Microsoft.AspNetCore.Mvc;

namespace Single_Device_Attendance_Recorder.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            // Show landing page 
            ViewBag.Message = TempData["Maligayang Araw"];
            return View();
        }

        // GET: Home/Welcome
        public IActionResult Welcome()
        {
            // Show welcome page (with optional TempData message)
            ViewBag.Message = TempData["Welcome"];
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Single_Device_Attendance_Recorder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Landing page
        }

        public IActionResult Welcome()
        {
            return View(); // Welcome page after login
        }
    }
}
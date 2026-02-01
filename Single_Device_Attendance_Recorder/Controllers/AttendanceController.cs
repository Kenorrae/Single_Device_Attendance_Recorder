using Microsoft.AspNetCore.Mvc;

namespace Single_Device_Attendance_Recorder.Controllers
{
    public class AttendanceController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string studentName, string date, string status)
        {
            TempData["Message"] = $"Attendance recorded for {studentName} on {date} as {status}.";
            return RedirectToAction("View");
        }

        [HttpGet]
        public IActionResult View()
        {
            return View();
        }
    }
}
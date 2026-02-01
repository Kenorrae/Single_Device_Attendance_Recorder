using Microsoft.AspNetCore.Mvc;
using Single_Device_Attendance_Recorder.Models;
using System.Linq;

namespace Single_Device_Attendance_Recorder.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly AttendanceDbContext _context;

        public AttendanceController(AttendanceDbContext context)
        {
            _context = context;
        }

        // GET: Attendance/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Pass a single empty record to the form
            return View(new AttendanceRecord());
        }

        // POST: Attendance/Create
        [HttpPost]
        public IActionResult Create(AttendanceRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.AttendanceRecords.Add(record);
                _context.SaveChanges();
                TempData["Message"] = $"Attendance recorded for {record.StudentName} on {record.Date.ToShortDateString()} as {record.Status}.";
                return RedirectToAction("View");
            }
            return View(record);
        }

        // GET: Attendance/View
        [HttpGet]
        public IActionResult View()
        {
            var records = _context.AttendanceRecords.ToList();
            return View(records); // Pass a list to the view
        }
    }
}
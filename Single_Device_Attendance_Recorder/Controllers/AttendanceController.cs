using Microsoft.AspNetCore.Mvc;
using Single_Device_Attendance_Recorder.Models;
using System;
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

        // Attendance/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Attendance/Create
        [HttpPost]
        public IActionResult Create(string studentName, DateTime date, string status)
        {
            if (string.IsNullOrWhiteSpace(studentName) || string.IsNullOrWhiteSpace(status))
            {
                ViewBag.Error = "Student name and status are required.";
                return View();
            }

            var record = new AttendanceRecord
            {
                StudentName = studentName,
                Date = date,
                Status = status
            };

            _context.AttendanceRecords.Add(record);
            _context.SaveChanges();

            TempData["Message"] = $"Attendance recorded for {studentName} on {date.ToShortDateString()} as {status}.";
            return RedirectToAction("View");
        }

        // Attendance/View
        [HttpGet]
        public IActionResult View()
        {
            var records = _context.AttendanceRecords.ToList();
            return View(records);
        }
    }
}
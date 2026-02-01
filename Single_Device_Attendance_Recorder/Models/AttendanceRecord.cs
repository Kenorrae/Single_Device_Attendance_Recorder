using System;
using System.ComponentModel.DataAnnotations;

namespace Single_Device_Attendance_Recorder.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
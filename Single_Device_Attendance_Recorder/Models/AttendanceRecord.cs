namespace Single_Device_Attendance_Recorder.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }       // Primary Key
        public string StudentName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
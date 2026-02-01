using Microsoft.EntityFrameworkCore;

namespace Single_Device_Attendance_Recorder.Models
{
    public class AttendanceDbContext : DbContext
    {
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
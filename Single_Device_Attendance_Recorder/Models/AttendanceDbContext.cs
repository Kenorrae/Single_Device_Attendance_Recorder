using Microsoft.EntityFrameworkCore;

namespace Single_Device_Attendance_Recorder.Models
{
    public class AttendanceDbContext : DbContext
    {
        // Constructor: passes options (like SQLite connection string) to base DbContext
        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options)
            : base(options) { }

        // Tables in your database (DbSets map to tables)
        public DbSet<User> Users { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
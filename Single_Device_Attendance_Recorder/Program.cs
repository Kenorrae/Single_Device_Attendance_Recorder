using Microsoft.EntityFrameworkCore;
using Single_Device_Attendance_Recorder.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Configure SQLite database using connection string from appsettings.json
builder.Services.AddDbContext<AttendanceDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route: Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
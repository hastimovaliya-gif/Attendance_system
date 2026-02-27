using Microsoft.EntityFrameworkCore;
using demoapplication.Model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Policy> Policies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Email unique

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

        // One attendance per employee per date

        modelBuilder.Entity<AttendanceRecord>()
            .HasIndex(a => new { a.EmployeeId, a.AttendanceDate })
            .IsUnique();

        // Seeding

        modelBuilder.Entity<Policy>().HasData(
            new Policy { PolicyId = 1, Name = "Policy1 8 Hours", MinDailyHours = 8 },
            new Policy { PolicyId = 2, Name = "Policy2 7.5 Hours", MinDailyHours = 7.5M },
            new Policy { PolicyId = 3, Name = "Policy3 9 Hours", MinDailyHours = 9 }
        );

        
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, PolicyId = 1, FirstName = "Ayush", LastName = "Sarvaiya", Email = "ayush@mx.com", IsActive = true },
            new Employee { EmployeeId = 2, PolicyId = 2, FirstName = "Hasti", LastName = "Movaliya", Email = "hasti@mx.com", IsActive = true },
            new Employee { EmployeeId = 3, PolicyId = 1, FirstName = "Hatim", LastName = "Chharchhoda", Email = "hatim@mx.com", IsActive = true },
            new Employee { EmployeeId = 4, PolicyId = 3, FirstName = "Srishti", LastName = "Singh", Email = "srishti@mx.com", IsActive = true },
            new Employee { EmployeeId = 5, PolicyId = 2, FirstName = "Veer", LastName = "Vora", Email = "veer@mx.com", IsActive = true }
        );

       
        modelBuilder.Entity<AttendanceRecord>().HasData(
            new AttendanceRecord { AttendanceId = 1, EmployeeId = 1, AttendanceDate = new DateTime(2026, 2, 24), Status = "Present", HoursWorked = 8.5M },
            new AttendanceRecord { AttendanceId = 2, EmployeeId = 2, AttendanceDate = new DateTime(2026, 2, 24), Status = "ShortHours", HoursWorked = 6.5M },
            new AttendanceRecord { AttendanceId = 3, EmployeeId = 3, AttendanceDate = new DateTime(2026, 2, 24), Status = "Absent", HoursWorked = 0 },
            new AttendanceRecord { AttendanceId = 4, EmployeeId = 4, AttendanceDate = new DateTime(2026, 2, 24), Status = "ShortHours", HoursWorked = 8 },
            new AttendanceRecord { AttendanceId = 5, EmployeeId = 5, AttendanceDate = new DateTime(2026, 2, 24), Status = "Present", HoursWorked = 7.5M }
        );
    }
}
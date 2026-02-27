using demoapplication.DTOs;
using Microsoft.EntityFrameworkCore;
namespace demoapplication.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DailyAttendanceReportDto>> GetDailyAttendanceAsync(DateTime date)
        {
            
            var query =
                from a in _context.AttendanceRecords
                join e in _context.Employees on a.EmployeeId equals e.EmployeeId
                join p in _context.Policies on e.PolicyId equals p.PolicyId
                where a.AttendanceDate == date.Date
                select new DailyAttendanceReportDto
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FirstName + " " + e.LastName,
                    PolicyName = p.Name,
                    MinDailyHours = p.MinDailyHours,
                    AttendanceDate = a.AttendanceDate,
                    Status = a.Status,
                    HoursWorked = a.HoursWorked,
                    DailyFlag = a.Status == "ShortHours"
                        ? "PolicyViolation"
                        : "OK"
                };

            return await query.ToListAsync();
        }
    }
}

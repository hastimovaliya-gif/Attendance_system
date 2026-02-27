using demoapplication.DTOs;
using demoapplication.Model;
using demoapplication.services;
using Microsoft.EntityFrameworkCore;

namespace demoapplication.Repository
{

    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;
        public AttendanceRepository(AppDbContext context) => _context = context;

        public async Task<bool> AttendanceExistsAsync(int employeeId, DateTime date)
            => await _context.AttendanceRecords.AnyAsync(a =>
                a.EmployeeId == employeeId &&
                a.AttendanceDate == date.Date);

        public async Task<Employee> GetEmployeeWithPolicyAsync(int employeeId)
            => await _context.Employees
                .Include(e => e.Policy)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        public async Task AddAsync(AttendanceRecord record)
        {
            _context.AttendanceRecords.Add(record);
            await _context.SaveChangesAsync();
        }
    }

}



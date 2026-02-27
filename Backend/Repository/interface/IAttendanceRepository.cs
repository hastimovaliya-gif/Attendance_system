using demoapplication.Model;
using demoapplication.DTOs;
namespace demoapplication.Repository
{
    public interface IAttendanceRepository
    {
        Task<bool> AttendanceExistsAsync(int employeeId, DateTime date);
        Task<Employee> GetEmployeeWithPolicyAsync(int employeeId);
        Task AddAsync(AttendanceRecord record);
    }

}

using demoapplication.Model;
using Microsoft.EntityFrameworkCore;
using demoapplication.DTOs;
using demoapplication.Repository;
namespace demoapplication.services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceService(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        public async Task MarkAttendanceAsync(AttendanceCreateDto dto)
        {
            if (dto.HoursWorked < 0 || dto.HoursWorked > 24)
                throw new ArgumentException("HoursWorked must be between 0 and 24");

            if (await _repo.AttendanceExistsAsync(dto.EmployeeId, dto.AttendanceDate))
                throw new InvalidOperationException("Attendance already marked");

            var employee = await _repo.GetEmployeeWithPolicyAsync(dto.EmployeeId);
            if (employee == null)
                throw new ArgumentException("Employee not found");

         
            if (dto.Status == "Absent")
            {
                dto.HoursWorked = 0;
            }
            else
            {
                if (dto.HoursWorked < employee.Policy.MinDailyHours)
                    dto.Status = "ShortHours";
                else
                    dto.Status = "Present";
            }

            var record = new AttendanceRecord
            {
                EmployeeId = dto.EmployeeId,
                AttendanceDate = dto.AttendanceDate.Date,
                Status = dto.Status,
                HoursWorked = dto.HoursWorked
            };

            await _repo.AddAsync(record);
        }
    }
}

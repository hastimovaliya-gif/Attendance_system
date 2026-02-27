using demoapplication.DTOs;
namespace demoapplication.services
{
    public interface IAttendanceService
    {
        Task MarkAttendanceAsync(AttendanceCreateDto dto);
    }


}

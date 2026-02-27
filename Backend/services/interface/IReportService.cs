using demoapplication.DTOs;

namespace demoapplication.services
{
    public interface IReportService
    {
        Task<List<DailyAttendanceReportDto>> GetDailyAttendanceReportAsync(DateTime date);
    }
}

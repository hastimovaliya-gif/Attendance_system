using demoapplication.DTOs;

namespace demoapplication.Repository
{
    public interface IReportRepository
    {
        Task<List<DailyAttendanceReportDto>> GetDailyAttendanceAsync(DateTime date);
    }
}

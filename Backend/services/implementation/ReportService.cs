using demoapplication.DTOs;
using demoapplication.Repository;
using static System.Object;

namespace demoapplication.services.implementation
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repo;

        public ReportService(IReportRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<DailyAttendanceReportDto>> GetDailyAttendanceReportAsync(DateTime date)
        {
            return await _repo.GetDailyAttendanceAsync(date);
        }
    }
}

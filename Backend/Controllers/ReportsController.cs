using demoapplication.DTOs;
using demoapplication.services;
using Microsoft.AspNetCore.Mvc;
using static System.Object;

namespace demoapplication.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportsController(IReportService service)
        {
            _service = service;
        }

       
        [HttpGet("daily-attendance")]
        public async Task<IActionResult> GetDailyAttendance([FromQuery] DateTime date)
        {
            var report = await _service.GetDailyAttendanceReportAsync(date);
            return Ok(report);
        }
    }
}

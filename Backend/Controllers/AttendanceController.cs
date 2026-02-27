using demoapplication.DTOs;
using demoapplication.services;
using Microsoft.AspNetCore.Mvc;

namespace demoapplication.Controllers
{
    [ApiController]
    [Route("api/attendance")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post(AttendanceCreateDto dto)
        {
            try
            {
                await _service.MarkAttendanceAsync(dto);
                return Ok();

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); 
            }
        }
    }



}

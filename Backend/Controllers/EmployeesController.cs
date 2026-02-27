using demoapplication.DTOs;
using demoapplication.services;
using Microsoft.AspNetCore.Mvc;

namespace demoapplication.Controllers
{
      [ApiController]
        [Route("api/employees")]
        public class EmployeesController : ControllerBase
        {
            private readonly IEmployeeService _service;

            public EmployeesController(IEmployeeService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
                => Ok(await _service.GetEmployeesAsync());



            [HttpPost]
            public async Task<IActionResult> Post(EmployeeCreateDto dto)
            {
                try
                {
                    await _service.CreateEmployeeAsync(dto);
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


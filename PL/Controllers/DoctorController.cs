using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // POST: api/Doctor/Register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterDoctor([FromBody] DoctorModel doctorModel, [FromQuery] Guid departmentId, [FromQuery] Guid specializationId)
        {
            if (doctorModel == null)
                return BadRequest("Invalid doctor data.");

            try
            {
                await _doctorService.RegisterDoctorAsync(doctorModel, departmentId, specializationId);
                return Ok("Doctor registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Doctor/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(id);
                return Ok(doctor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Doctor not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

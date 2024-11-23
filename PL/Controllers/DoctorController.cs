/*using Business.Models;
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
        public async Task<IActionResult> RegisterDoctor([FromBody] DoctorModel doctorModel)
        {
            if (doctorModel == null)
                return BadRequest("Invalid doctor data.");
            try
            {
                await _doctorService.RegisterDoctorAsync(doctorModel);
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

        // GET: api/Doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Doctor/{id}/WorkHistory
        [HttpGet("{id}/WorkHistory")]
        public async Task<IActionResult> GetDoctorWorkHistory(Guid id)
        {
            try
            {
                var workHistory = await _doctorService.GetDoctorWorkHistoryAsync(id);
                return Ok(workHistory);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Doctor not found or no work history available.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Doctor/{id}/CurrentWorkplace
        [HttpGet("{id}/CurrentWorkplace")]
        public async Task<IActionResult> GetCurrentWorkplace(Guid id)
        {
            try
            {
                var currentWorkplace = await _doctorService.GetCurrentWorkplaceAsync(id);
                if (currentWorkplace == null)
                    return NotFound("No current workplace found for the doctor.");
                return Ok(currentWorkplace);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Doctor/{id}/Workplace
        [HttpPut("{id}/Workplace")]
        public async Task<IActionResult> UpdateDoctorWorkplace(Guid id, [FromBody] WorkplaceUpdateModel model)
        {
            if (model == null)
                return BadRequest("Invalid workplace update data.");
            try
            {
                await _doctorService.UpdateDoctorWorkplaceAsync(id, model.DepartmentId, model.SpecializationId);
                return Ok("Doctor workplace updated successfully.");
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

        // GET: api/Doctor/{id}/WorkplaceDetails
        [HttpGet("{id}/WorkplaceDetails")]
        public async Task<IActionResult> GetDoctorWorkplaceDetails(Guid id)
        {
            try
            {
                var workplaceDetails = await _doctorService.GetDoctorWorkplaceDetailsAsync(id);
                if (workplaceDetails == null)
                    return NotFound("No workplace details found for the doctor.");
                return Ok(workplaceDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    // Модель для оновлення робочого місця
    public class WorkplaceUpdateModel
    {
        public Guid DepartmentId { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
*/
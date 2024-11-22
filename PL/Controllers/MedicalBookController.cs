using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalBookController : ControllerBase
    {
        private readonly IMedicalBookService _medicalBookService;

        public MedicalBookController(IMedicalBookService medicalBookService)
        {
            _medicalBookService = medicalBookService;
        }

        [HttpGet("{medicalBookId}")]
        public async Task<IActionResult> GetMedicalBook(Guid medicalBookId)
        {
            var medicalBook = await _medicalBookService.GetMedicalBookByIdAsync(medicalBookId);
            return Ok(medicalBook);
        }

        [HttpGet("{medicalBookId}/records")]
        public async Task<IActionResult> GetMedicalRecords(Guid medicalBookId)
        {
            var records = await _medicalBookService.GetRecordsByMedicalBookIdAsync(medicalBookId);
            return Ok(records);
        }

        [HttpGet("records/{recordId}/tests")]
        public async Task<IActionResult> GetTestPrescriptions(Guid recordId)
        {
            var testPrescriptions = await _medicalBookService.GetTestPrescriptionsByRecordIdAsync(recordId);
            return Ok(testPrescriptions);
        }

        [HttpGet("records/{recordId}/treatments")]
        public async Task<IActionResult> GetTreatmentPrescriptions(Guid recordId)
        {
            var treatmentPrescriptions = await _medicalBookService.GetTreatmentPrescriptionsByRecordIdAsync(recordId);
            return Ok(treatmentPrescriptions);
        }

        [HttpGet("records/{recordId}/doctor")]
        public async Task<IActionResult> GetDoctor(Guid recordId)
        {
            var doctor = await _medicalBookService.GetDoctorByRecordIdAsync(recordId);
            return Ok(doctor);
        }
        
        // ==============================================
        // Medical Book Operations
        // ==============================================

        // Отримати всі медичні книги
        [HttpGet]
        public async Task<IActionResult> GetAllMedicalBooks()
        {
            var medicalBooks = await _medicalBookService.GetAllMedicalBooksAsync();
            return Ok(medicalBooks);
        }

        // Створити нову медичну книгу
        [HttpPost]
        public async Task<IActionResult> CreateMedicalBook([FromBody] MedicalBookModel model)
        {
            var createdBook = await _medicalBookService.CreateMedicalBookAsync(model);
            return CreatedAtAction(nameof(GetAllMedicalBooks), new { medicalBookId = createdBook.Id }, createdBook);
        }

        // Оновити медичну книгу
        [HttpPut("{medicalBookId}")]
        public async Task<IActionResult> UpdateMedicalBook(Guid medicalBookId, [FromBody] MedicalBookModel model)
        {
            await _medicalBookService.UpdateMedicalBookAsync(medicalBookId, model);
            return NoContent();
        }

        // Видалити медичну книгу
        [HttpDelete("{medicalBookId}")]
        public async Task<IActionResult> DeleteMedicalBook(Guid medicalBookId)
        {
            await _medicalBookService.DeleteMedicalBookAsync(medicalBookId);
            return NoContent();
        }
        
        // ==============================================
        // Medical Record Operations
        // ==============================================

        // Створити новий медичний запис
        [HttpPost("records")]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] MedicalRecordModel model)
        {
            var createdRecord = await _medicalBookService.CreateMedicalRecordAsync(model);
            return CreatedAtAction(nameof(GetMedicalRecord), new { recordId = createdRecord.Id }, createdRecord);
        }

        // Оновити медичний запис
        [HttpPut("records/{recordId}")]
        public async Task<IActionResult> UpdateMedicalRecord(Guid recordId, [FromBody] MedicalRecordModel model)
        {
            await _medicalBookService.UpdateMedicalRecordAsync(recordId, model);
            return NoContent();
        }

        // Видалити медичний запис
        [HttpDelete("records/{recordId}")]
        public async Task<IActionResult> DeleteMedicalRecord(Guid recordId)
        {
            await _medicalBookService.DeleteMedicalRecordAsync(recordId);
            return NoContent();
        }

        // Отримати медичний запис за ID
        [HttpGet("records/{recordId}")]
        public async Task<IActionResult> GetMedicalRecord(Guid recordId)
        {
            var record = await _medicalBookService.GetMedicalRecordByIdAsync(recordId);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // ==============================================
        // Test Prescription Operations
        // ==============================================

        // Створити новий рецепт на тест
        [HttpPost("records/{recordId}/tests")]
        public async Task<IActionResult> CreateTestPrescription(Guid recordId, [FromBody] TestPrescriptionModel model)
        {
            model.MedicalRecordId = recordId; // Прив'язка до медичного запису
            var createdTestPrescription = await _medicalBookService.CreateTestPrescriptionAsync(model);
            return CreatedAtAction(nameof(GetTestPrescription), new { prescriptionId = createdTestPrescription.Id }, createdTestPrescription);
        }

        // Оновити рецепт на тест
        [HttpPut("tests/{prescriptionId}")]
        public async Task<IActionResult> UpdateTestPrescription(Guid prescriptionId, [FromBody] TestPrescriptionModel model)
        {
            await _medicalBookService.UpdateTestPrescriptionAsync(prescriptionId, model);
            return NoContent();
        }

        // Видалити рецепт на тест
        [HttpDelete("tests/{prescriptionId}")]
        public async Task<IActionResult> DeleteTestPrescription(Guid prescriptionId)
        {
            await _medicalBookService.DeleteTestPrescriptionAsync(prescriptionId);
            return NoContent();
        }

        // Отримати рецепт на тест за ID
        [HttpGet("tests/{prescriptionId}")]
        public async Task<IActionResult> GetTestPrescription(Guid prescriptionId)
        {
            var prescription = await _medicalBookService.GetTestPrescriptionByIdAsync(prescriptionId);
            if (prescription == null)
                return NotFound();

            return Ok(prescription);
        }

        // ==============================================
        // Treatment Prescription Operations
        // ==============================================

        // Створити новий рецепт на лікування
        [HttpPost("records/{recordId}/treatments")]
        public async Task<IActionResult> CreateTreatmentPrescription(Guid recordId, [FromBody] TreatmentPrescriptionModel model)
        {
            model.MedicalRecordId = recordId; // Прив'язка до медичного запису
            var createdTreatmentPrescription = await _medicalBookService.CreateTreatmentPrescriptionAsync(model);
            return CreatedAtAction(nameof(GetTreatmentPrescription), new { prescriptionId = createdTreatmentPrescription.Id }, createdTreatmentPrescription);
        }

        // Оновити рецепт на лікування
        [HttpPut("treatments/{prescriptionId}")]
        public async Task<IActionResult> UpdateTreatmentPrescription(Guid prescriptionId, [FromBody] TreatmentPrescriptionModel model)
        {
            await _medicalBookService.UpdateTreatmentPrescriptionAsync(prescriptionId, model);
            return NoContent();
        }

        // Видалити рецепт на лікування
        [HttpDelete("treatments/{prescriptionId}")]
        public async Task<IActionResult> DeleteTreatmentPrescription(Guid prescriptionId)
        {
            await _medicalBookService.DeleteTreatmentPrescriptionAsync(prescriptionId);
            return NoContent();
        }

        // Отримати рецепт на лікування за ID
        [HttpGet("treatments/{prescriptionId}")]
        public async Task<IActionResult> GetTreatmentPrescription(Guid prescriptionId)
        {
            var prescription = await _medicalBookService.GetTreatmentPrescriptionByIdAsync(prescriptionId);
            if (prescription == null)
                return NotFound();

            return Ok(prescription);
        }
    }

}

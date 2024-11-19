namespace BLL.Models
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid RoleId { get; set; }
        public Guid GenderId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }

    public class RoleModel : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Guid> Users { get; set; }
    }

    public class GenderModel : BaseModel
    {
        public string Name { get; set; }
        public ICollection<Guid> Users { get; set; }
    }

    public class PatientModel : BaseModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid GenderId { get; set; }
        public Guid RoleId { get; set; }

        public Guid MedicalBookId { get; set; }
    }

    public class MedicalBookModel : BaseModel
    {
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid PatientId { get; set; }
        public ICollection<Guid> MedicalRecordIds { get; set; } = new List<Guid>();
    }

    public class MedicalRecordModel : BaseModel
    {
        public Guid MedicalBookId { get; set; }
        public Guid DiagnosisId { get; set; }
        public Guid DoctorId { get; set; }
        public string Notes { get; set; }
        public ICollection<Guid> TreatmentPrescriptionIds { get; set; } = new List<Guid>();
        public ICollection<Guid> ReferralPrescriptionIds { get; set; } = new List<Guid>();
        public ICollection<Guid> TestPrescriptionIds { get; set; } = new List<Guid>();
        public Guid? RoomId { get; set; }
    }

    public class DiagnosisModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Guid> MedicalRecords { get; set; }
    }

    public class TreatmentPrescriptionModel : BaseModel
    {
        public DateTime RecordDate { get; set; }
        public string Notes { get; set; }
        public Guid MedicalRecordId { get; set; }
        public ICollection<Guid> TreatmentIds { get; set; } = new List<Guid>();
    }

    public class TreatmentModel : BaseModel
    {
        public Guid TreatmentPlanId { get; set; }
        public Guid MedicineId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
    }

    public class MedicineModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid MedicineTypeId { get; set; }
        public Guid ManufacturerId { get; set; }
        public Guid DosageId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ICollection<Guid> Treatments { get; set; }
    }

    public class MedicineTypeModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Guid> Medicines { get; set; }
    }

    public class ManufacturerModel : BaseModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public ICollection<Guid> Medicines { get; set; }
    }

    public class DosageModel : BaseModel
    {
        public string DosageAmount { get; set; }
        public string UsageInstructions { get; set; }
        public ICollection<Guid> Medicines { get; set; }
    }

    public class ReferralPrescriptionModel : BaseModel
    {
        public DateTime RecordDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid DoctorId { get; set; }
        public Guid MedicalRecordId { get; set; }
        public string Notes { get; set; }
    }

    public class TestPrescriptionModel : BaseModel
    {
        public DateTime RecordDate { get; set; }
        public Guid MedicalRecordId { get; set; }
        public string Notes { get; set; }
        public ICollection<Guid> MedicalTestIds { get; set; } = new List<Guid>();
    }

    public class MedicalTestModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Result { get; set; }
        public Guid TestPrescriptionId { get; set; }
    }
}

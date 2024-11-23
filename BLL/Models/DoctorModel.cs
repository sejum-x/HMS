using DAL.Entities;

namespace Business.Models
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string CityName { get; set; }
        public Guid CityId { get; set; }
        public string RegionName { get; set; } 
        public Guid RegionId { get; set; } 
        public string CountryName { get; set; } 
        public Guid CountryId { get; set; }
    }

    public class DoctorDTO
    {
        public Guid Id { get; set; }

        // Особисті дані лікаря
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarImage { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Гендер і роль
        public Guid RoleId { get; set; }
        public Guid GenderId { get; set; }

        // Специфічні дані для лікаря
        public ICollection<Guid> MedicalRecords { get; set; } = new List<Guid>();
        public ICollection<Guid> WorkHistory { get; set; } = new List<Guid>();
        public ICollection<Guid> ReferralPrescriptions { get; set; } = new List<Guid>();
        public ICollection<Guid> Awards { get; set; } = new List<Guid>();
        public ICollection<Guid> Certificates { get; set; } = new List<Guid>();
    }

    public class PatientDTO
    {
        public Guid Id { get; set; }

        // Особисті дані пацієнта
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarImage { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Гендер і роль
        public Guid RoleId { get; set; }
        public Guid GenderId { get; set; }

        // Специфічні дані для пацієнта
        public Guid MedicalBookId { get; set; }
    }


    public class AuthUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }
        public string UserType { get; set; } // "Doctor" або "Patient"
    }



    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DepartmentType { get; set; }
        public Guid HospitalId { get; set; }
    }

    
    public class HospitalDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }

    public class AwardDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AwardedDate { get; set; }
    }

    public class CertificateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime IssuedDate { get; set; }
    }

    public class DiagnosisDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoomDTO
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public Guid DepartmentId { get; set; }
    }

    public class MedicalRecordDTO
    {
        public Guid Id { get; set; }
        public Guid MedicalBookId { get; set; }
        public MedicalBookDTO MedicalBook { get; set; }

        public Guid DiagnosisId { get; set; }
        public DiagnosisDTO Diagnosis { get; set; }

        public Guid DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }

        public string Notes { get; set; }

        public ICollection<TreatmentPrescriptionDTO> TreatmentPrescriptions { get; set; } = new List<TreatmentPrescriptionDTO>();
        public ICollection<ReferralPrescriptionDTO> ReferralPrescriptions { get; set; } = new List<ReferralPrescriptionDTO>();
        public ICollection<TestPrescriptionDTO> TestPrescriptions { get; set; } = new List<TestPrescriptionDTO>();

        public Guid? RoomId { get; set; }
        public RoomDTO Room { get; set; }
    }

    public class TreatmentPrescriptionDTO
    {
        public Guid Id { get; set; }
        public DateTime RecordDate { get; set; }
        public string Notes { get; set; }

        public Guid MedicalRecordId { get; set; }
        public MedicalRecordDTO MedicalRecord { get; set; }

        public ICollection<TreatmentDTO> Treatments { get; set; } = new List<TreatmentDTO>();
    }


    public class TreatmentDTO
    {
        public Guid Id { get; set; }
        public Guid TreatmentPrescriptionId { get; set; }
        public TreatmentPrescriptionDTO TreatmentPrescription { get; set; }

        public Guid MedicineId { get; set; }
        public MedicineDTO Medicine { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
    }

    public class MedicineDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid MedicineTypeId { get; set; }
        public MedicineTypeDTO MedicineType { get; set; }

        public Guid ManufacturerId { get; set; }
        public ManufacturerDTO Manufacturer { get; set; }

        public Guid DosageId { get; set; }
        public DosageDTO Dosage { get; set; }

        public DateTime ExpirationDate { get; set; }
    }


    public class ReferralPrescriptionDTO
    {
        public Guid Id { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public string ReferredDoctorName { get; set; }
        public Guid MedicalRecordId { get; set; }
    }

    public class MedicalBookDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; } 
        public DateTime IssueDate { get; set; } 
        public Guid PatientId { get; set; } 
        public PatientDTO Patient { get; set; }
        public ICollection<MedicalRecordDTO> MedicalRecords { get; set; } = new List<MedicalRecordDTO>();
    }

    public class DoctorWorkHistoryDTO
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }

        public Guid DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }

        public Guid DoctorSpecializationId { get; set; }
        public DoctorSpecializationDTO DoctorSpecialization { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class GenderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class TestPrescriptionDTO
    {
        public Guid Id { get; set; }
        public string Notes { get; set; }
        public DateTime RecordDate { get; set; }
    }

    public class MedicineTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ManufacturerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }

    public class DosageDTO
    {
        public Guid Id { get; set; }
        public string DosageAmount { get; set; }
        public string UsageInstructions { get; set; }
    }

    public class DoctorSpecializationDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
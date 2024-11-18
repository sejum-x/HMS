using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    // Репозиторії
    public IUserRepository Users { get; }
    public IDoctorRepository Doctors { get; }
    public IPatientRepository Patients { get; }
    public IMedicalBookRepository MedicalBooks { get; }
    public IMedicalRecordRepository MedicalRecords { get; }
    public IDiagnosisRepository Diagnoses { get; }
    public ITreatmentPrescriptionRepository TreatmentPrescriptions { get; }
    public ITreatmentRepository Treatments { get; }
    public IMedicineRepository Medicines { get; }
    public IDoctorSpecializationRepository DoctorSpecializations { get; }
    public IDoctorWorkHistoryRepository DoctorWorkHistories { get; }
    public IRoomRepository Rooms { get; }
    public IDepartmentRepository Departments { get; }

    // Конструктор
    public UnitOfWork(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        // Ініціалізація репозиторіїв
        Users = new UserRepository(context);
        Doctors = new DoctorRepository(context);
        Patients = new PatientRepository(context);
        MedicalBooks = new MedicalBookRepository(context);
        MedicalRecords = new MedicalRecordRepository(context);
        Diagnoses = new DiagnosisRepository(context);
        TreatmentPrescriptions = new TreatmentPrescriptionRepository(context);
        Treatments = new TreatmentRepository(context);
        Medicines = new MedicineRepository(context);
        DoctorSpecializations = new DoctorSpecializationRepository(context);
        DoctorWorkHistories = new DoctorWorkHistoryRepository(context);
        Rooms = new RoomRepository(context);
        Departments = new DepartmentRepository(context);
    }

    // Метод для збереження змін в базі даних
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    // Реалізація IDisposable для правильного очищення ресурсів
    public void Dispose()
    {
        _context.Dispose();
    }
}
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HMSDbContext _context;

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
    public IGenderRepository Genders { get; }
    public IRoleRepository Roles { get; }
    public ITestPrescriptionRepository TestPrescriptions { get; }

    public IAddressRepository Addresses { get; }
    public ICityRepository Cities { get; }
    public IRegionRepository Regions { get; }
    public ICountryRepository Countries { get; }


    // Конструктор
    public UnitOfWork(HMSDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

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
        Roles = new RoleRepository(context);
        Genders = new GenderRepository(context);
        Addresses = new AddressRepository(context);
        Cities = new CityRepository(context);
        Regions = new RegionRepository(context);
        Countries = new CountryRepository(context);
        TestPrescriptions = new TestPrescriptionRepository(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
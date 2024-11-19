using DAL.Configuration;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public class HMSDbContext : DbContext
{
    /* private readonly IConfiguration _configuration;

     public HMSDbContext(IConfiguration configuration)
     {
         _configuration = configuration;
     }

     protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlServer(_configuration.GetConnectionString("HMSDbContext"));
     }*/

    public HMSDbContext(DbContextOptions<HMSDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentType> DepartmentTypes { get; set; }
    public DbSet<Diagnosis> Diagnoses { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
    public DbSet<DoctorWorkHistory> DoctorWorkHistories { get; set; }
    public DbSet<Dosage> Dosages { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<MedicalBook> MedicalBooks { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<MedicalTest> MedicalTests { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MedicineType> MedicineTypes { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<TreatmentPrescription> TreatmentPrescriptions { get; set; }
    public DbSet<ReferralPrescription> ReferralPrescriptions { get; set; }
    public DbSet<TestPrescription> TestPrescriptions { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Award> Awards { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new AwardConfiguration());
        modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DiagnosisConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorSpecializationConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorWorkHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new DosageConfiguration());
        modelBuilder.ApplyConfiguration(new GenderConfiguration());
        modelBuilder.ApplyConfiguration(new HospitalConfiguration());
        modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalBookConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalRecordConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalTestConfiguration());
        modelBuilder.ApplyConfiguration(new MedicineConfiguration());
        modelBuilder.ApplyConfiguration(new MedicineTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new ReferralPrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new RegionConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TestPrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
        modelBuilder.ApplyConfiguration(new TreatmentPrescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());


        base.OnModelCreating(modelBuilder);
    }
}
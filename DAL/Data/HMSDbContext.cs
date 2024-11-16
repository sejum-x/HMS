using DAL.Entities;
using Microsoft.EntityFrameworkCore;

public class HMSDbContext : DbContext
{
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
}
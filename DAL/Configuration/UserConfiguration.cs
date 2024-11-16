using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Gender)
                .WithMany()
                .HasForeignKey(u => u.GenderId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.User)
            .WithOne(u => u.Patient)
            .HasForeignKey<Patient>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.MedicalBook)
            .WithOne(mb => mb.Patient)
            .HasForeignKey<Patient>(p => p.MedicalBookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.UserId)
            .IsRequired();

        builder.HasOne(d => d.User)
            .WithOne(u => u.Doctor)
            .HasForeignKey<Doctor>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.MedicalRecords)
            .WithOne(mr => mr.Doctor)
            .HasForeignKey(mr => mr.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.WorkHistory)
            .WithOne(wh => wh.Doctor)
            .HasForeignKey(wh => wh.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.ReferralPrescriptions)
            .WithOne(rp => rp.Doctor)
            .HasForeignKey(rp => rp.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Awards)
            .WithOne(a => a.Doctor)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.Certificates)
            .WithOne(c => c.Doctor)
            .HasForeignKey(c => c.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class DoctorWorkHistoryConfiguration : IEntityTypeConfiguration<DoctorWorkHistory>
{
    public void Configure(EntityTypeBuilder<DoctorWorkHistory> builder)
    {
        builder.HasKey(dwh => dwh.Id);

        builder.HasOne(dwh => dwh.Doctor)
            .WithMany(d => d.WorkHistory)
            .HasForeignKey(dwh => dwh.DoctorId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(dwh => dwh.Department)
            .WithMany(d => d.WorkHistories)
            .HasForeignKey(dwh => dwh.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dwh => dwh.DoctorSpecialization)
            .WithMany(ds => ds.DoctorWorkHistories)
            .HasForeignKey(dwh => dwh.DoctorSpecializationId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}

public class DoctorSpecializationConfiguration : IEntityTypeConfiguration<DoctorSpecialization>
{
    public void Configure(EntityTypeBuilder<DoctorSpecialization> builder)
    {
        builder.HasKey(ds => ds.Id);

        builder.Property(ds => ds.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ds => ds.Description)
            .HasMaxLength(500);

        builder.HasMany(ds => ds.DoctorWorkHistories)
            .WithOne(dwh => dwh.DoctorSpecialization)
            .HasForeignKey(dwh => dwh.DoctorSpecializationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Hospital)
            .WithMany(h => h.Departments)
            .HasForeignKey(d => d.HospitalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.DepartmentType)
            .WithMany(dt => dt.Departments)
            .HasForeignKey(d => d.DepartmentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Rooms)
            .WithOne(r => r.Department)
            .HasForeignKey(r => r.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.WorkHistories)
            .WithOne(dwh => dwh.Department)
            .HasForeignKey(dwh => dwh.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class DepartmentTypeConfiguration : IEntityTypeConfiguration<DepartmentType>
{
    public void Configure(EntityTypeBuilder<DepartmentType> builder)
    {
        builder.HasKey(dt => dt.Id);

        builder.HasMany(dt => dt.Departments)
            .WithOne(d => d.DepartmentType)
            .HasForeignKey(d => d.DepartmentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(h => h.Address)
            .WithMany()
            .HasForeignKey(h => h.AddressId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasMany(h => h.Departments)
            .WithOne(d => d.Hospital)
            .HasForeignKey(d => d.HospitalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Department)
            .WithMany(d => d.Rooms)
            .HasForeignKey(r => r.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.RoomType)
            .WithMany()
            .HasForeignKey(r => r.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.MedicalRecords)
            .WithOne(p => p.Room)
            .HasForeignKey(mr => mr.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.HasKey(mr => mr.Id);

        builder.HasOne(mr => mr.MedicalBook)
            .WithMany(mb => mb.MedicalRecords)
            .HasForeignKey(mr => mr.MedicalBookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mr => mr.Diagnosis)
            .WithMany(d => d.MedicalRecords)
            .HasForeignKey(mr => mr.DiagnosisId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mr => mr.Doctor)
            .WithMany(d => d.MedicalRecords)
            .HasForeignKey(mr => mr.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(mr => mr.TreatmentPrescriptions)
            .WithOne(tp => tp.MedicalRecord)
            .HasForeignKey(tp => tp.MedicalRecordId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(mr => mr.ReferralPrescriptions)
            .WithOne(rp => rp.MedicalRecord)
            .HasForeignKey(rp => rp.MedicalRecordId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(mr => mr.TestPrescriptions)
            .WithOne(tp => tp.MedicalRecord)
            .HasForeignKey(tp => tp.MedicalRecordId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(mr => mr.Room)
            .WithMany(r => r.MedicalRecords)
            .HasForeignKey(mr => mr.RoomId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(mr => mr.Notes)
            .HasMaxLength(500);
    }
}

public class MedicalBookConfiguration : IEntityTypeConfiguration<MedicalBook>
{
    public void Configure(EntityTypeBuilder<MedicalBook> builder)
    {
        builder.HasKey(mb => mb.Id);

        builder.Property(mb => mb.Number)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(mb => mb.IssueDate)
            .IsRequired();

        builder.HasOne(mb => mb.Patient) 
            .WithOne(p => p.MedicalBook) 
            .HasForeignKey<MedicalBook>(mb => mb.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(mb => mb.MedicalRecords)
            .WithOne(mr => mr.MedicalBook)
            .HasForeignKey(mr => mr.MedicalBookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class TreatmentPrescriptionConfiguration : IEntityTypeConfiguration<TreatmentPrescription>
{
    public void Configure(EntityTypeBuilder<TreatmentPrescription> builder)
    {
        builder.HasKey(tp => tp.Id);

        builder.Property(tp => tp.RecordDate)
            .IsRequired();

        builder.Property(tp => tp.Notes)
            .HasMaxLength(500);

        builder.HasOne(tp => tp.MedicalRecord)
            .WithMany(mr => mr.TreatmentPrescriptions)
            .HasForeignKey(tp => tp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(tp => tp.Treatments)
            .WithOne(t => t.TreatmentPrescription)
            .HasForeignKey(t => t.TreatmentPlanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.TreatmentPrescription)
            .WithMany(tp => tp.Treatments)
            .HasForeignKey(t => t.TreatmentPlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Medicine)
            .WithMany(m => m.Treatments)
            .HasForeignKey(t => t.MedicineId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.StartDate)
            .IsRequired();

        builder.Property(t => t.EndDate)
            .IsRequired();

        builder.Property(t => t.Notes)
            .HasMaxLength(500);
    }
}

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(500);

        builder.HasOne(m => m.MedicineType)
            .WithMany(mt => mt.Medicines)
            .HasForeignKey(m => m.MedicineTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Manufacturer)
            .WithMany(man => man.Medicines)
            .HasForeignKey(m => m.ManufacturerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Dosage)
            .WithMany(d => d.Medicines)
            .HasForeignKey(m => m.DosageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(m => m.ExpirationDate)
            .IsRequired();
    }
}

public class ReferralPrescriptionConfiguration : IEntityTypeConfiguration<ReferralPrescription>
{
    public void Configure(EntityTypeBuilder<ReferralPrescription> builder)
    {
        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.RecordDate)
            .IsRequired();

        builder.Property(rp => rp.StartDate)
            .IsRequired();

        builder.Property(rp => rp.EndDate)
            .IsRequired();

        builder.HasOne(rp => rp.Doctor)
            .WithMany(d => d.ReferralPrescriptions)
            .HasForeignKey(rp => rp.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rp => rp.MedicalRecord)
            .WithMany(mr => mr.ReferralPrescriptions)
            .HasForeignKey(rp => rp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(rp => rp.Notes)
            .HasMaxLength(500);
    }
}

public class TestPrescriptionConfiguration : IEntityTypeConfiguration<TestPrescription>
{
    public void Configure(EntityTypeBuilder<TestPrescription> builder)
    {
        builder.HasKey(tp => tp.Id);

        builder.Property(tp => tp.RecordDate)
            .IsRequired();

        builder.HasOne(tp => tp.MedicalRecord)
            .WithMany(mr => mr.TestPrescriptions)
            .HasForeignKey(tp => tp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(tp => tp.Notes)
            .HasMaxLength(500);

        builder.HasMany(tp => tp.MedicalTests)
            .WithOne(mt => mt.TestPrescription)
            .HasForeignKey(mt => mt.TestPrescriptionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class MedicalTestConfiguration : IEntityTypeConfiguration<MedicalTest>
{
    public void Configure(EntityTypeBuilder<MedicalTest> builder)
    {
        builder.HasKey(mt => mt.Id);

        builder.Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(mt => mt.Description)
            .HasMaxLength(500);

        builder.Property(mt => mt.DateAssigned)
            .IsRequired();

        builder.Property(mt => mt.DateCompleted);

        builder.Property(mt => mt.Result)
            .HasMaxLength(500);
    }
}

public class DiagnosisConfiguration : IEntityTypeConfiguration<Diagnosis>
{
    public void Configure(EntityTypeBuilder<Diagnosis> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.HasMany(d => d.MedicalRecords)
            .WithOne(mr => mr.Diagnosis)
            .HasForeignKey(mr => mr.DiagnosisId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.BuildingNumber)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasOne(a => a.City)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class AwardConfiguration : IEntityTypeConfiguration<Award>
{
    public void Configure(EntityTypeBuilder<Award> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Description)
            .HasMaxLength(500);

        builder.Property(a => a.AwardedDate)
            .IsRequired();

        builder.HasOne(a => a.Doctor)
            .WithMany(d => d.Awards)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.IssuedDate)
            .IsRequired();

        builder.HasOne(c => c.Doctor)
            .WithMany(d => d.Certificates)
            .HasForeignKey(c => c.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(c => c.Region)
            .WithMany(r => r.Cities)
            .HasForeignKey(c => c.RegionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(r => r.Country)
            .WithMany(c => c.Regions)
            .HasForeignKey(r => r.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(c => c.Regions)
            .WithOne(r => r.Country)
            .HasForeignKey(r => r.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class DosageConfiguration : IEntityTypeConfiguration<Dosage>
{
    public void Configure(EntityTypeBuilder<Dosage> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.DosageAmount)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.UsageInstructions)
            .HasMaxLength(500);

        builder.HasMany(d => d.Medicines)
            .WithOne(m => m.Dosage)
            .HasForeignKey(m => m.DosageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(g => g.Users)
            .WithOne(u => u.Gender)
            .HasForeignKey(u => u.GenderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Country)
            .HasMaxLength(100);

        builder.Property(m => m.Email)
            .HasMaxLength(100);

        builder.HasMany(m => m.Medicines)
            .WithOne(med => med.Manufacturer)
            .HasForeignKey(med => med.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class MedicineTypeConfiguration : IEntityTypeConfiguration<MedicineType>
{
    public void Configure(EntityTypeBuilder<MedicineType> builder)
    {
        builder.HasKey(mt => mt.Id);

        builder.Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(mt => mt.Description)
            .HasMaxLength(500);

        builder.HasMany(mt => mt.Medicines)
            .WithOne(m => m.MedicineType)
            .HasForeignKey(m => m.MedicineTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(rt => rt.Description)
            .HasMaxLength(500);

        builder.HasMany(rt => rt.Rooms)
            .WithOne(r => r.RoomType)
            .HasForeignKey(r => r.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
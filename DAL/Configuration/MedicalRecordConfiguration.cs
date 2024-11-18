using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.HasKey(mr => mr.Id);

        builder.HasOne(mr => mr.MedicalBook)
            .WithMany(mb => mb.MedicalRecords)
            .HasForeignKey(mr => mr.MedicalBookId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(mr => mr.Diagnosis)
            .WithMany(d => d.MedicalRecords)
            .HasForeignKey(mr => mr.DiagnosisId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(mr => mr.Doctor)
            .WithMany(d => d.MedicalRecords)
            .HasForeignKey(mr => mr.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(mr => mr.TreatmentPrescriptions)
            .WithOne(tp => tp.MedicalRecord)
            .HasForeignKey(tp => tp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(mr => mr.ReferralPrescriptions)
            .WithOne(rp => rp.MedicalRecord)
            .HasForeignKey(rp => rp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(mr => mr.TestPrescriptions)
            .WithOne(tp => tp.MedicalRecord)
            .HasForeignKey(tp => tp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(mr => mr.Room)
            .WithMany(r => r.MedicalRecords)
            .HasForeignKey(mr => mr.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(mr => mr.Notes)
            .HasMaxLength(500);
    }
}
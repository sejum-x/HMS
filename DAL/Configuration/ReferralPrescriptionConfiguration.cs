using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rp => rp.MedicalRecord)
            .WithMany(mr => mr.ReferralPrescriptions)
            .HasForeignKey(rp => rp.MedicalRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(rp => rp.Notes)
            .HasMaxLength(500);
    }
}
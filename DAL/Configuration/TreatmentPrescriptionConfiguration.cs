using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(tp => tp.Treatments)
            .WithOne(t => t.TreatmentPrescription)
            .HasForeignKey(t => t.TreatmentPlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.TreatmentPrescription)
            .WithMany(tp => tp.Treatments)
            .HasForeignKey(t => t.TreatmentPlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Medicine)
            .WithMany(m => m.Treatments)
            .HasForeignKey(t => t.MedicineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(t => t.StartDate)
            .IsRequired();

        builder.Property(t => t.EndDate)
            .IsRequired();

        builder.Property(t => t.Notes)
            .HasMaxLength(500);
    }
}
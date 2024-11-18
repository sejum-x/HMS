using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(tp => tp.Notes)
            .HasMaxLength(500);

        builder.HasMany(tp => tp.MedicalTests)
            .WithOne(mt => mt.TestPrescription)
            .HasForeignKey(mt => mt.TestPrescriptionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
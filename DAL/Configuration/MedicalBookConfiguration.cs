using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(mb => mb.MedicalRecords)
            .WithOne(mr => mr.MedicalBook)
            .HasForeignKey(mr => mr.MedicalBookId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Manufacturer)
            .WithMany(man => man.Medicines)
            .HasForeignKey(m => m.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Dosage)
            .WithMany(d => d.Medicines)
            .HasForeignKey(m => m.DosageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(m => m.ExpirationDate)
            .IsRequired();
    }
}
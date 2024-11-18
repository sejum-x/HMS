using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
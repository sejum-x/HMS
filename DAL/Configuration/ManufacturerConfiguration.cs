using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
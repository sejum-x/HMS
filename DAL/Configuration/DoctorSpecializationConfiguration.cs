using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorSpecializationConfiguration : IEntityTypeConfiguration<DoctorSpecialization>
{
    public void Configure(EntityTypeBuilder<DoctorSpecialization> builder)
    {
        builder.HasKey(ds => ds.Id);

        builder.Property(ds => ds.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ds => ds.Description)
            .HasMaxLength(500);

        builder.HasMany(ds => ds.DoctorWorkHistories)
            .WithOne(dwh => dwh.DoctorSpecialization)
            .HasForeignKey(dwh => dwh.DoctorSpecializationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
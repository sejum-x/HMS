using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorWorkHistoryConfiguration : IEntityTypeConfiguration<DoctorWorkHistory>
{
    public void Configure(EntityTypeBuilder<DoctorWorkHistory> builder)
    {
        builder.HasKey(dwh => dwh.Id);

        builder.HasOne(dwh => dwh.Doctor)
            .WithMany(d => d.WorkHistory)
            .HasForeignKey(dwh => dwh.DoctorId)
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(dwh => dwh.Department)
            .WithMany(d => d.WorkHistories)
            .HasForeignKey(dwh => dwh.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dwh => dwh.DoctorSpecialization)
            .WithMany(ds => ds.DoctorWorkHistories)
            .HasForeignKey(dwh => dwh.DoctorSpecializationId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
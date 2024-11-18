using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasOne(d => d.Hospital)
            .WithMany(h => h.Departments)
            .HasForeignKey(d => d.HospitalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.DepartmentType)
            .WithMany(dt => dt.Departments)
            .HasForeignKey(d => d.DepartmentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Rooms)
            .WithOne(r => r.Department)
            .HasForeignKey(r => r.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.WorkHistories)
            .WithOne(dwh => dwh.Department)
            .HasForeignKey(dwh => dwh.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
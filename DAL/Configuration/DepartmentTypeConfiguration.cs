using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DepartmentTypeConfiguration : IEntityTypeConfiguration<DepartmentType>
{
    public void Configure(EntityTypeBuilder<DepartmentType> builder)
    {
        builder.HasKey(dt => dt.Id);

        builder.HasMany(dt => dt.Departments)
            .WithOne(d => d.DepartmentType)
            .HasForeignKey(d => d.DepartmentTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
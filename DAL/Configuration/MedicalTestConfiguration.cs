using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MedicalTestConfiguration : IEntityTypeConfiguration<MedicalTest>
{
    public void Configure(EntityTypeBuilder<MedicalTest> builder)
    {
        builder.HasKey(mt => mt.Id);

        builder.Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(mt => mt.Description)
            .HasMaxLength(500);

        builder.Property(mt => mt.DateAssigned)
            .IsRequired();

        builder.Property(mt => mt.DateCompleted);

        builder.Property(mt => mt.Result)
            .HasMaxLength(500);
    }
}
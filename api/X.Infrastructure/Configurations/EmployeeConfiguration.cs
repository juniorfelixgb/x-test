using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Domain.Employees;

namespace X.Infrastructure.Configurations;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(t => t.LastName)
               .HasMaxLength(50)
               .IsRequired();
    }
}

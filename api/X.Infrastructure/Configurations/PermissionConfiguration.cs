using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Domain.Permissions;

namespace X.Infrastructure.Configurations;

internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Employee)
               .WithMany(t => t.Permissions)
               .HasForeignKey(t => t.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.PermissionType);

        builder.Property(t => t.SubmittedDate)
               .IsRequired();
    }
}

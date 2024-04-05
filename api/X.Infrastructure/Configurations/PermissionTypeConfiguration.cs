using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using X.Domain.Permissions;

namespace X.Infrastructure.Configurations;

internal sealed class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Description)
               .HasMaxLength(100)
               .IsRequired();
    }
}

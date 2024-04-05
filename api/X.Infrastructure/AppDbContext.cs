using Microsoft.EntityFrameworkCore;
using X.Domain.Employees;
using X.Domain.Permissions;
using X.Domain.Shared.Interfaces;

namespace X.Infrastructure;

internal sealed class AppDbContext : DbContext, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionType> PermissionTypes { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(DependencyInyection.CurrentAssembly);
        base.OnModelCreating(modelBuilder);
        Seed(modelBuilder);
    }

    protected async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    private void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PermissionType>()
                    .HasData(
                    new PermissionType { Id = 1, Description = "Medical" },
                         new PermissionType { Id = 2, Description = "Personal" },
                         new PermissionType { Id = 3, Description = "Other" });

        modelBuilder.Entity<Employee>()
                    .HasData(new Employee
                    {
                        Id = 1,
                        FirstName = "Test",
                        LastName = "Test",
                    });
    }
}

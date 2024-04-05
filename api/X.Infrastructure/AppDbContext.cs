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
    }

    protected async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

}

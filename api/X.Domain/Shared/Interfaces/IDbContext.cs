using Microsoft.EntityFrameworkCore;
using X.Domain.Employees;
using X.Domain.Permissions;

namespace X.Domain.Shared.Interfaces;

public interface IDbContext : IAsyncDisposable
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionType> PermissionTypes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

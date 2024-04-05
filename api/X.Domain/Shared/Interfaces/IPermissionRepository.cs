using System.Linq.Expressions;
using X.Domain.Permissions;

namespace X.Domain.Shared.Interfaces;

public interface IPermissionRepository
{
    Task<List<Permission>> GetAllAsync();
    Task<Permission> GetAsync(Expression<Func<Permission, bool>> predicate);
    Task<Permission> Create(Permission permission);
}

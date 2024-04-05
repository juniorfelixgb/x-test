using System.Linq.Expressions;
using X.Domain.Permissions;

namespace X.Domain.Shared.Interfaces;

public interface IPermissionTypeRepository
{
    Task<List<PermissionType>> GetTypes();
    Task<bool> Exist(Expression<Func<PermissionType, bool>> predicate);
}

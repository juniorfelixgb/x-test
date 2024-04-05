using X.Domain.Permissions;

namespace X.Domain.Shared.Interfaces;

public interface IPermissionService
{
    Task<List<Permission>> GetAll();
    Task<List<PermissionType>> GetTypes();
    Task<Permission> GetById(int id);
    Task<Permission> Create(Permission permission);
}

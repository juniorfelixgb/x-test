using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.Domain.Permissions;
using X.Domain.Shared.Interfaces;

namespace X.Infrastructure.Repositories;

internal sealed class PermissionTypeRepository : IPermissionTypeRepository
{
    private readonly IDbContext context;

    public PermissionTypeRepository(IDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> Exist(Expression<Func<PermissionType, bool>> predicate)
    {
        return await this.context.PermissionTypes.AnyAsync(predicate);
    }

    public async Task<List<PermissionType>> GetTypes()
    {
        return await this.context.PermissionTypes.ToListAsync();
    }
}

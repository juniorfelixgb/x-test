using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.Domain.Permissions;
using X.Domain.Shared.Interfaces;

namespace X.Infrastructure.Repositories;

internal sealed class PermissionRepository : IPermissionRepository
{
    private readonly IDbContext context;

    public PermissionRepository(IDbContext context)
    {
        this.context = context;
    }

    public async Task<Permission> Create(Permission permission)
    {
        var result = await this.context.Permissions.AddAsync(permission);
        await this.context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<List<Permission>> GetAllAsync()
    {
        var query = await (
            from permission in this.context.Permissions.DefaultIfEmpty()
            join employee in this.context.Employees.DefaultIfEmpty() on permission.EmployeeId equals employee.Id
            select new Permission
            {
                Id = permission.Id,
                EmployeeId = employee.Id,
                Employee = employee,
                PermissionType = permission.PermissionType,
                PermissionTypeId = permission.PermissionTypeId,
                SubmittedDate = permission.SubmittedDate,
            }).ToListAsync();

        return query;
    }

    public async Task<Permission> GetAsync(Expression<Func<Permission, bool>> predicate)
    {
        var query = await (
            from permission in this.context.Permissions.DefaultIfEmpty()
            join employee in this.context.Employees.DefaultIfEmpty() on permission.EmployeeId equals employee.Id
            select new Permission
            {
                Id = permission.Id,
                EmployeeId = employee.Id,
                Employee = employee,
                PermissionType = permission.PermissionType,
                PermissionTypeId = permission.PermissionTypeId,
                SubmittedDate = permission.SubmittedDate,
            }).FirstOrDefaultAsync(predicate);

        return query;
    }
}

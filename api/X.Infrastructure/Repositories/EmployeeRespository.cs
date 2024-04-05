using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.Domain.Employees;
using X.Domain.Shared.Interfaces;

namespace X.Infrastructure.Repositories;

internal sealed class EmployeeRespository : IEmployeeRespository
{
    private readonly IDbContext context;

    public EmployeeRespository(IDbContext context)
    {
        this.context = context;
    }

    public async Task<Employee> Get(Expression<Func<Employee, bool>> predicate)
    {
        return await context.Employees.FirstOrDefaultAsync(predicate);
    }
}

using System.Linq.Expressions;
using X.Domain.Employees;

namespace X.Domain.Shared.Interfaces;

public interface IEmployeeRespository
{
    Task<bool> Exist(Expression<Func<Employee, bool>> predicate);
}

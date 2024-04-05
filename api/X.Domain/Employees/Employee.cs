using X.Domain.Permissions;

namespace X.Domain.Employees;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Permission> Permissions { get; set; }
}

using X.Domain.Employees;
using X.Domain.Permissions.Enums;

namespace X.Domain.Permissions;

public class Permission
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int PermissionTypeId { get; set; }
    public PermissionType PermissionType { get; set; }
    public DateTime SubmittedDate { get; set; }
}

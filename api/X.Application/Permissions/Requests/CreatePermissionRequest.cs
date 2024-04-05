using X.Domain.Permissions.Enums;

namespace X.Application.Permissions.Requests;

public class CreatePermissionRequest
{
    public string EmployeeName { get; set; }
    public PermissionType PermissionType { get; set; } = PermissionType.None;
}

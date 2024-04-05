using X.Application.Permissions.Requests;
using X.Domain.Permissions;

namespace X.Application.Permissions.Extensions;

public static class PermissionExtensions
{
    public static Permission ToPermission(this CreatePermissionRequest request)
    {
        return new Permission
        {
            EmployeeId = request.EmployeeId,
            PermissionTypeId = Convert.ToInt32(request.PermissionType),
            SubmittedDate = DateTime.UtcNow,
        };
    }
}

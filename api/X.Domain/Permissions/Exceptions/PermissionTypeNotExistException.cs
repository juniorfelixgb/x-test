namespace X.Domain.Permissions.Exceptions;

public class PermissionTypeNotExistException : Exception
{
    public PermissionTypeNotExistException(int permissionType) : base($"The permission type: {permissionType} especified does not exist!") { }
}

namespace X.Domain.Employees.Exceptions;

public class EmployeeNotExistException : Exception
{
    public EmployeeNotExistException(int employeeId) : base($"The employee: {employeeId} especified does not exist!") { }
}

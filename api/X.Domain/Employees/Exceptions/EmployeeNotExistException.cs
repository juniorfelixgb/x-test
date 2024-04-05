namespace X.Domain.Employees.Exceptions;

public class EmployeeNotExistException : Exception
{
    public EmployeeNotExistException(string employeeName) : base($"The employee: {employeeName} especified does not exist!") { }
}

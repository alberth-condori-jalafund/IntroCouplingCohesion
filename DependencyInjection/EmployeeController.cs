namespace DependencyInjection;

using System.Collections.Generic;
using System.Linq;

public class EmployeeController
{
    private readonly IEmployeeDataAccess _dataAccess;

    public EmployeeController(IEmployeeDataAccess dataAccess)
    {
        _dataAccess = dataAccess; 
    }

    public List<Employee> GetAllEmployees()
    {
        return _dataAccess.SelectAllEmployees().ToList();
    }
}

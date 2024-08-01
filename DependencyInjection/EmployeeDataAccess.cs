namespace DependencyInjection;

using System;
using System.Collections.Generic;

public interface IEmployeeDataAccess
{
    IEnumerable<Employee> SelectAllEmployees();
}

public class EmployeeDataAccess : IEmployeeDataAccess
{
    public IEnumerable<Employee> SelectAllEmployees()
    {
        return new List<Employee>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Alberth",
                Department = "Engineering"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Luis",
                Department = "People"
            }
        };
    }
}

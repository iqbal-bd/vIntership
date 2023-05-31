using EmployeeProject.Model;
using System.Collections.Generic;
namespace EmployeeProject.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);

        Employee Update(Employee updatedEmployee);

        Employee Add(Employee employee);

        Employee Delete(int id);


    }
}
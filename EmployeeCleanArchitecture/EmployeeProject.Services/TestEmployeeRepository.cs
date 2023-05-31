using EmployeeProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject.Services
{
    public class TestEmployeeRepository:IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public TestEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, FirstName = "Kamran", LastName = "Hasan", Email = "kamran@gmail.com",
                Department = Dept.Software,PhotoPath = "software.jpg",EnrollmentDate=DateOnly.Parse("2022-09-01")},
            };
        }



        /*------ Add new Employee ------*/
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }


        /*------Get all Employees ------*/
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }


        /*------ Get Single Employee by Id ------*/
        public Employee GetEmployee(int id)
        {
            return _employeeList.First(e => e.Id == id);
        }

        /*------ Update Employee ------*/
        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if(employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.EnrollmentDate = updatedEmployee.EnrollmentDate;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }
            return employee;
        }

        public Employee Delete(int id)
        {
            var employeeToDelete = _employeeList.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                _employeeList.Remove(employeeToDelete);
            }

            return employeeToDelete;
        }

       
    }
}

using BeratenKatuwahDomain.Employee;

namespace BeratenKatuwahDataAccess.Ifaces
{
    public interface IEmployeeService
    {

        int CreateEmployee(EmployeeModel employeeModel);
        IList<EmployeeModel> GetEmployeeList();
        EmployeeModel GetEmployeeById(int id);
        EmployeeModel Update(EmployeeModel employeeModel);
        EmployeeModel Delete (int id);
    }
}


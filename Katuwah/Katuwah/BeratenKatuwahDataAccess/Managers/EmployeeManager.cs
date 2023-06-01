using BeratenKatuwahDataAccess.DbModel;
using BeratenKatuwahDataAccess.Ifaces;
using BeratenKatuwahDataAccess.Migrations;
using BeratenKatuwahDomain.Employee;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeratenKatuwahDataAccess.Managers
{
    public class EmployeeManager : BaseDataManager, IEmployeeService
    {
        public EmployeeManager(EmployeeDbContext model) : base(model)
        {
        }

        /*------- Create new Employee-------*/
        public int CreateEmployee(EmployeeModel employeeModel)
        {
            AddUpdateEntity(employeeModel);
            return employeeModel.Id;
        }


        /*------ Get all Employee ------*/
        public IList<EmployeeModel> GetEmployeeList()
        {
            return dbModel.EmployeeModel.ToList();
        }


        /*------ Get single Employee Id for Edit ------*/
        public EmployeeModel GetEmployeeById(int id)
        {
            return dbModel.EmployeeModel.ToList().FirstOrDefault(x => x.Id == id);
        }

        /*------ Update Edited employee data ------*/
        public EmployeeModel Update(EmployeeModel employeeModel)
        {
            EmployeeModel EmployeeModel = dbModel.EmployeeModel.ToList().FirstOrDefault(e => e.Id == employeeModel.Id);

            if (EmployeeModel != null)
            {
                EmployeeModel.FirstName = employeeModel.FirstName;
                EmployeeModel.LastName = employeeModel.LastName;
            }
            return EmployeeModel;
        }

        /*------ Delete employee by id ------*/
        public EmployeeModel Delete(int id)
        {
            EmployeeModel employeeToDelete = dbModel.EmployeeModel.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                dbModel.Remove(employeeToDelete);
            }

            return employeeToDelete;
        }



    }
}


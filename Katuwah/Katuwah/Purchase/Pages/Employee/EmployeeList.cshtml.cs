using BeratenKatuwahDataAccess.Ifaces;
using BeratenKatuwahDomain.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Purchase.Pages.Employee
{
    public class EmployeeListModel : PageModel
    {
        [BindProperty]
        public IList<EmployeeModel> EmployeeList { get; set; }
        public int EmployeeId { get; set; }
        private readonly IEmployeeService m_Employee;
        public EmployeeListModel(IEmployeeService employeeService)
        {
            m_Employee = employeeService;

        }


        public void OnGet()
        {
            try
            {
                EmployeeList = m_Employee.GetEmployeeList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using BeratenKatuwahDataAccess.Ifaces;
using BeratenKatuwahDataAccess.Migrations;
using BeratenKatuwahDomain.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Purchase.Pages.Employee
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; }

        public DeleteModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

    }
}

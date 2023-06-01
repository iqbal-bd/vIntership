using BeratenKatuwahDataAccess.Ifaces;
using BeratenKatuwahDomain.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Purchase.Pages.Employee
{
    public class AddEmployeeModel : PageModel
    {
        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; }

        private readonly IEmployeeService m_Employee;
        public AddEmployeeModel(IEmployeeService employeeService)
        {
            m_Employee = employeeService;

        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                m_Employee.CreateEmployee(EmployeeModel);

                TempData["Message"] = "Employee added successfully";
                return RedirectToPage("/Employee/EmployeeList", new EmployeeModel());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}


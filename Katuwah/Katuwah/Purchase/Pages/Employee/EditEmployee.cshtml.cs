using BeratenKatuwahDataAccess.Ifaces;
using BeratenKatuwahDataAccess.Migrations;
using BeratenKatuwahDomain.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Telerik.SvgIcons;

namespace Purchase.Pages.Employee
{
    public class EditEmployeeModel : PageModel
    {
        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; }

        private readonly IEmployeeService m_Employee;
        public EditEmployeeModel(IEmployeeService employeeService)
        {
            m_Employee = employeeService;

        }
        public IActionResult OnGet(int id)
        {
            EmployeeModel = m_Employee.GetEmployeeById(id);

            if (EmployeeModel == null)
            {
                return RedirectToPage("/Not found");
            }
            return Page();
        }




        public IActionResult OnPost(EmployeeModel employeeModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                EmployeeModel = m_Employee.Update(employeeModel);
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

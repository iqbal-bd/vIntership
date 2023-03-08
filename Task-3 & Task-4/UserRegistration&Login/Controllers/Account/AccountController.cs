using Microsoft.AspNetCore.Mvc;
using UserRegistration_Login.Models.ViewModel;

namespace UserRegistration_Login.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login_SignUp model)
        {
            return View();
        }

        public IActionResult SignUP()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUP(Login_SignUp model) 
        {
            return View();
        }
    }
}

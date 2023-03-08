using Microsoft.AspNetCore.Mvc;

namespace UserRegistration_Login.Controllers.Account
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUP()
        {
            return View();
        }
    }
}

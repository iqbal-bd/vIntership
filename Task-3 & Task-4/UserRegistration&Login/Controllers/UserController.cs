using Microsoft.AspNetCore.Mvc;
using UserRegistration_Login.Data;

namespace UserRegistration_Login.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext context;

        public UserController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Users.ToList();
            return View(result);
        }

        public IActionResult Create() 
        {
            return View();
        }
    }
}

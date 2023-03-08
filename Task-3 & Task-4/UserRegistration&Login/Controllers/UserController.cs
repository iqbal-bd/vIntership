using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UserRegistration_Login.Data;
using UserRegistration_Login.Models;

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

        [HttpPost]
        public IActionResult Create(User name)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    FirstName = name.FirstName,
                    LastName = name.LastName,
                    FullName=name.FullName,
                    Email = name.Email,
                    District = name.District,
                    PostCode = name.PostCode,
                    Division = name.Division

                };
                context.Users.Add(user);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");          }
            else
            {
                TempData["message"] = "Empty field can't submit";
                return View(name);
            }
        }
        public IActionResult Delete(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.ID == id);
            context.Users.Remove(user);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var user = context.Users.FirstOrDefault(u=>u.ID == id);
            var update = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Email = user.Email,
                District = user.District,
                PostCode = user.PostCode,
                Division = user.Division
            };
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(User name)
        {
            var user = new User()
            {
                ID = name.ID,
                FirstName = name.FirstName,
                LastName = name.LastName,
                FullName = name.FullName,
                Email = name.Email,
                District = name.District,
                PostCode = name.PostCode,
                Division = name.Division

            };
            context.Users.Update(user);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }

    }
}

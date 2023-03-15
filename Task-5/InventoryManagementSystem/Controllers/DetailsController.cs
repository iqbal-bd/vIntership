using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ApplicationContext context;

        public DetailsController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var result = context.PurchaseDetails.Include("header").ToList();
            return View(result);
        }



        [HttpGet]
        public IActionResult CreateDetails()
        {

            return View();
        }

       
    }
}

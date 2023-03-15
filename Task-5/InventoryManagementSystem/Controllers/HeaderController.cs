using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class HeaderController : Controller
    {
        private readonly ApplicationContext context;

        public HeaderController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Purchase.ToList();
            return View(result);
        }

   

        

        [HttpGet]
        public IActionResult Purchase() 
        {
        
            return View();
        }

        [HttpPost]
        public IActionResult Purchase(Header name)
        {
            if (ModelState.IsValid)
            {
                var purchase = new Header()
                {
                    PurchaseDate = name.PurchaseDate,
                    SupplierName = name.SupplierName,
                    Address = name.Address,
                    EntryBy = name.EntryBy,
                    EntryDate = name.EntryDate,
                    Remark = name.Remark
                };
                context.Purchase.Add(purchase);
                context.SaveChanges();
                TempData["error"] = "Record Saved!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty field can't submit";
                return View(name);
            }
        }

        public IActionResult Delete(int id)
        {
            var purchase = context.Purchase.SingleOrDefault(u => u.PurchaseId == id);
            context.Purchase.Remove(purchase);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            var purchase = context.Purchase.SingleOrDefault(u => u.PurchaseId == id);
            var result = new Header()
            {
                PurchaseDate = purchase.PurchaseDate,
                SupplierName = purchase.SupplierName,
                Address = purchase.Address,
                EntryBy = purchase.EntryBy,
                EntryDate = purchase.EntryDate,
                Remark = purchase.Remark
            };
            return View(result);
        }


        [HttpPost]
        public IActionResult Edit(Header name)
        {
            var Purchase = new Header()
            {
                PurchaseDate = name.PurchaseDate,
                SupplierName = name.SupplierName,
                Address = name.Address,
                EntryBy = name.EntryBy,
                EntryDate = name.EntryDate,
                Remark = name.Remark
            };
            context.Purchase.Update(Purchase);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }
    }
}

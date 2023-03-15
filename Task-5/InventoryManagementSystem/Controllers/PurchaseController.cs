using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ApplicationContext context;

        public PurchaseController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {   
            var result = context.PurchaseDetails.ToList();
            return View(result);
        }

        public IActionResult CreatePurchase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePurchase(Detail name)
        {

            var purchase = new Detail()
            {
                PurchaseId = name.PurchaseId,
                ItemCode = name.ItemCode,
                ItemQty = name.ItemQty,
                ItemUnitId = name.ItemUnitId,
                ItemRate = name.ItemRate
            };
            context.PurchaseDetails.Add(purchase);
            context.SaveChanges();
            TempData["error"] = "Record Saved!";
            return RedirectToAction("Index");
            
        }

         public IActionResult Delete(int id)
        {
            var purchase = context.PurchaseDetails.SingleOrDefault(u => u.Id == id);
            context.PurchaseDetails.Remove(purchase);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) 
        {
            var purchase = context.PurchaseDetails.SingleOrDefault(u => u.Id == id);
            var result = new Detail()
            {
                PurchaseId = purchase.PurchaseId,
                ItemCode = purchase.ItemCode,
                ItemQty = purchase.ItemQty,
                ItemUnitId = purchase.ItemUnitId,
                ItemRate = purchase.ItemRate
            };
            return View(result);
        }


        [HttpPost]
        public IActionResult Edit(Detail name)
        {
            var Purchase = new Detail()
            {
                PurchaseId = name.PurchaseId,
                ItemCode = name.ItemCode,
                ItemQty = name.ItemQty,
                ItemUnitId = name.ItemUnitId,
                ItemRate = name.ItemRate
            };
            context.PurchaseDetails.Update(Purchase);
            context.SaveChanges();
            TempData["error"] = "Record Updated!";
            return RedirectToAction("Index");
        }
    }
}

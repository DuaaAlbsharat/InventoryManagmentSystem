using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagmentSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managmentEntities db = new Inventory_managmentEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> ListPurchase = db.Purchases.OrderByDescending(x => x.Id).ToList();
            return View(ListPurchase);
        }
        [HttpGet]
        public ActionResult PurchasePorduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchasePorduct(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase", "Purchase");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pro = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(int id , Purchase purchase)
        {
            var pro = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            pro.Purchase_Date = purchase.Purchase_Date;
            pro.Purchase_name = purchase.Purchase_name;
            pro.Purchase_qnty = purchase.Purchase_qnty;
            return RedirectToAction("DisplayPurchase", "Purchase");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var purchase = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            return View(purchase);
        }
        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            var purchase = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            return View(purchase);
        }
        [HttpPost]
        public ActionResult DeletePurchase(Purchase purchase)
        {
            var pro = db.Purchases.Where(x => x.Id == purchase.Id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                db.Purchases.Remove(pro);
                db.SaveChanges();
                return RedirectToAction("DisplayPurchase", "Purchase");
            }
            return View(pro);
        }
    }
}
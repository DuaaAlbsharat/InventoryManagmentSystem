using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagmentSystem.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managmentEntities db = new Inventory_managmentEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> ListSale = db.Sales.OrderByDescending(x => x.Id).ToList();
            return View(ListSale);
        }
        [HttpGet]
        public ActionResult SalePorduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SalePorduct(Sale sale)
        {
            db.Sales.Add(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale", "Sale");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pro = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            List<string> list = db.Sales.Select(x => x.Sale_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(int id , Sale sale)
        {
            var pro = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            pro.Sale_name = sale.Sale_name;
            pro.Sale_qnty = sale.Sale_qnty;
            pro.Sale_Date = sale.Sale_Date;
            return RedirectToAction("DisplaySale", "Sale");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var sale = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            return View(sale);
        }
        [HttpGet]
        public ActionResult DeleteSale(int id)
        {
            var sale = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            return View(sale);
        }
        [HttpPost]
        public ActionResult DeleteSale(Sale sale)
        {
            var pro = db.Sales.Where(x => x.Id == sale.Id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                db.Sales.Remove(pro);
                db.SaveChanges();
                return RedirectToAction("DisplaySale", "Sale");
            }
            return View(pro);
        }
    }
}
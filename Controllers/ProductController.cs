using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagmentSystem.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managmentEntities db = new Inventory_managmentEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> ListProduct = db.Products.OrderByDescending(x => x.Id).ToList();
            return View(ListProduct);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
           
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("DisplayProduct", "Product");
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Product pro = db.Products.Where(x => x.Id == id).SingleOrDefault();

            return View(pro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct( Product product , int id)
        {
            Product pro = db.Products.Where(x => x.Id == id).SingleOrDefault();


            if (ModelState.IsValid)
            {
                pro.Product_name = product.Product_name;
                pro.Product_qnty = product.Product_qnty;
                db.SaveChanges();
                return RedirectToAction("DisplayProduct", "Product");
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = db.Products.Where(x => x.Id == id).SingleOrDefault();
            return View(product);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            var product = db.Products.Where(x => x.Id == id).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct( Product product)
        {
            var pro = db.Products.Where(x => x.Id == product.Id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                db.Products.Remove(pro);
                db.SaveChanges();
                return RedirectToAction("DisplayProduct", "Product");
            }
            return View(pro);
        }
    }
}
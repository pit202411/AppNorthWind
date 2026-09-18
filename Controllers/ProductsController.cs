using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AppNorthWind;

namespace AppNorthWind.Controllers
{
    public class ProductsController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            using (var db = new NorthwindEntities())
            {
                var products = db.Products
                        .Include(p => p.Categories)
                       // .Where(p => p.UnitPrice > 20 && p.CategoryID == 6)
                        .ToList();

                return View(products);
            }
        }
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID
            );

            ViewBag.SupplierID = new SelectList(
                db.Suppliers,
                "SupplierID",
                "CompanyName",
                product.SupplierID
            );

            return View(product);
        }
    }
}
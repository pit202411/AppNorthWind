using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AppNorthWind;
using System.Net;
using System.Net;
using System.Web.Mvc;

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
            ViewBag.SupplierID = new SelectList(
                db.Suppliers,
                "SupplierID",
                "CompanyName",
                product.SupplierID
            );
            ViewBag.CategoryID = new SelectList(
                db.Categories,
                "CategoryID",
                "CategoryName",
                product.CategoryID
            );

            

            return View(product);
        }
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Products products = db.Products.Find(id);

            if (products == null)
                return HttpNotFound();
            
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", products.CategoryID);
            ViewBag.SupplierID = new SelectList(
                db.Suppliers,
                "SupplierID",
                "CompanyName",
                products.SupplierID
            );


            return View(products);
        }
        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(products);
        }
    }
}
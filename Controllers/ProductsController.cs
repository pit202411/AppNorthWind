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
using System.Web.Helpers;
using AppNorthWind.Services;
using System.Web.Services.Description;
using System.Threading.Tasks;

namespace AppNorthWind.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService productsService;
       


        public ProductsController()
        {
            productsService = new ProductsService();
        }


        public async Task<ActionResult> Index(string sortOrder)
        {
            var products = await productsService.GetProductsAsync(sortOrder);

            return View(products);
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryID = new SelectList(await productsService.GetCategoriesAsync(), "CategoryID", "CategoryName");
          //  ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Products product)
        {

            if (ModelState.IsValid)
            {
             productsService.CreateProduct(product);
            

                return RedirectToAction("Index");
            }
        
              ViewBag.CategoryID = new SelectList(await
                  productsService.GetCategoriesAsync(),
                   "CategoryID",
                   "CategoryName",
                   product.CategoryID
               );
            



            return View(product);
        }
        // GET: Products/Edit/5
      /*  public ActionResult Edit(int? id)
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
      */
        // POST: Products/Edit/5
      /*  [HttpPost]
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
      */
    }
}
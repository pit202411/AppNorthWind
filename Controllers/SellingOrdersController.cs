using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AppNorthWind.Models;
using System.Web.UI;
using AppNorthWind.Services;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;

namespace AppNorthWind.Controllers
{
    public class SellingOrdersController : Controller
    {
        private readonly SellingOrdersService sellingOrdersService ;
        private readonly ProductsService productsService ;

        public SellingOrdersController()
        {
            sellingOrdersService = new SellingOrdersService();
            productsService = new ProductsService();
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.IdEmployee = new SelectList(await sellingOrdersService.GetEmployeesAsync(), "EmployeeID", "LastName");
            ViewBag.IdProduct = new SelectList(await productsService.GetProductsAsync(), "ProductID", "ProductName");
            // ViewBag.CategoryID = new SelectList(await productsService.GetCategoriesAsync(), "CategoryID", "CategoryName");
            //  ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Selling_Orders selling_Orders)
        {

            if (ModelState.IsValid)
            {
                sellingOrdersService.CreateSellingOrder(selling_Orders);




                return RedirectToAction("Index");
            }






            return View(selling_Orders);
        }


        // GET: SellingOrders
        public async Task<ActionResult> Index(string sortOrder, int page = 1)
        {

            var products = await sellingOrdersService.GetSellingOrdersAsync(sortOrder);

            const int pageSize = 15;

            var model = new PagedViewModel<Selling_Orders>
            {
                Items = products
            };

            return View(model);
        }

        // GET: SellingOrders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       

      

        // GET: SellingOrders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellingOrders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SellingOrders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellingOrders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      
    }
}

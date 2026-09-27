using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppNorthWind.Controllers
{
    public class Selling_OrdersController : Controller
    {
        // GET: Selling_Orders
        public ActionResult Index()
        {
            return View();
        }

        // GET: Selling_Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Selling_Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Selling_Orders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Selling_Orders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Selling_Orders/Edit/5
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

        // GET: Selling_Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Selling_Orders/Delete/5
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

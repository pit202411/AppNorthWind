using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

namespace AppNorthWind.Services
{
    public class ProductsService
    {
        public async Task<List<Products>> GetProductsAsync(string sortOrder)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ProductsApiUrl"]);

                var response = await client.GetAsync("api/Products");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<Products>>(json);

                switch (sortOrder)
                {
                    case "ProductNameAsc":
                        products = products.OrderBy(p => p.ProductName).ToList();
                        break;
                    case "ProductNameDesc":
                        products = products.OrderByDescending(p => p.ProductName).ToList();
                        break;

                    case "SupplierName":
                        products = products.OrderBy(p => p.SupplierName).ToList();
                        break;


                    default:
                        products = products.OrderBy(p => p.ProductName).ToList();
                        break;
                }

                return products;
            }

        }
        public async Task<List<Categories>> GetCategoriesAsync(string sortOrder)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ProductsApiUrl"]);

                var response = await client.GetAsync("api/Categories");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var categories = JsonConvert.DeserializeObject<List<Categories>>(json);

               // switch (sortOrder)
              //  {
              //      
              //  }

                return categories;
            }
        }
        public async Task<List<Categories>> GetCategoriesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ProductsApiUrl"]);

                var response = await client.GetAsync("api/Categories");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var categories = JsonConvert.DeserializeObject<List<Categories>>(json);

             

                return categories;
            }
        }

        public Products GetProduct(int id)
        {
            using (var db = new NorthwindEntities())
            {
                return db.Products
                    .Include(p => p.Categories)
                    .FirstOrDefault(p => p.ProductID == id);
            }
        }
        public void CreateProduct(Products product) 
        {
            using (var db = new NorthwindEntities()) 
            { 
                db.Products.Add(product);
                db.SaveChanges(); }
        } 
        public bool UpdateProduct(Products product) 
        { 
            using (var db = new NorthwindEntities()) 
            { 
                var existingProduct = db.Products .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (existingProduct == null) 
                { return false; } 
                existingProduct.ProductName = product.ProductName;
                existingProduct.SupplierID = product.SupplierID;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.QuantityPerUnit = product.QuantityPerUnit;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                existingProduct.UnitsOnOrder = product.UnitsOnOrder;
                existingProduct.ReorderLevel = product.ReorderLevel;
                existingProduct.Discontinued = product.Discontinued;
                db.SaveChanges(); return true; } } 
                                               
        public bool DeleteProduct(int id) 
        { 
            using (var db = new NorthwindEntities()) 
            { 
                var product = db.Products .FirstOrDefault(p => p.ProductID == id);
                if (product == null) 
                { 
                    return false; 
                } db.Products.Remove(product);
                db.SaveChanges();
                return true;
            } 
        }
      


    }
}
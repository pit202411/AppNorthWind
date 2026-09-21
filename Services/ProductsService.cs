using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppNorthWind.Services
{
    public class ProductsService
    {
        public async Task<List<Products>> GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7094/");

                var response = await client.GetAsync("api/Products");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<Products>>(json);

                return products;
            }




            /*
             SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE Discontinued = 1;*/
            /*
             SELECT
    ProductID,
    ProductName,
    UnitsInStock
FROM Products
WHERE UnitsInStock < 20
ORDER BY UnitsInStock ASC;*/
            /*
             SELECT
    ProductID,
    ProductName,
    UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 10 AND 30
ORDER BY UnitPrice;*/
            /*
             SELECT
    ProductID,
    ProductName,
    UnitPrice
FROM Products
WHERE ProductName LIKE '%chocolate%';*/
            /*
             SELECT
    AVG(UnitPrice) AS AveragePrice,
    MIN(UnitPrice) AS MinimumPrice,
    MAX(UnitPrice) AS MaximumPrice
FROM Products;*/
            /*
             SELECT
    Discontinued,
    COUNT(*) AS ProductCount
FROM Products
GROUP BY Discontinued;*/
            /**/
            /**/
            /**/
            /**/
            /**/
            /**/
            /**/
            /**/
            /**/
            /**/
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
        public List<Categories> GetCategories()
        {
            using (var db = new NorthwindEntities())
            {
                return db.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
            }
        }


    }
}
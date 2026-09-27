using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace AppNorthWind.Services
{
    public class SellingOrdersService
    {

        public async Task<List<Selling_Orders>> GetSellingOrdersAsync(string sortOrder)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ProductsApiUrl"]);

                var response = await client.GetAsync("api/SellingOrders");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var sellingOrders = JsonConvert.DeserializeObject<List<Selling_Orders>>(json);


                return sellingOrders;
            }
        }
        public async Task<List<Employees>> GetEmployeesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ProductsApiUrl"]);

                var response = await client.GetAsync("api/Employees");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var employees = JsonConvert.DeserializeObject<List<Employees>>(json);



                return employees;
            }
        }
        public async Task<List<Products>> GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ProductsApiUrl"]);

                var response = await client.GetAsync("api/Products");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<Products>>(json);



                return products;
            }
        }
        public void CreateSellingOrder(Selling_Orders selling_Orders)
        {
            using (var db = new NorthwindEntities())
            {
                db.Selling_Orders.Add(selling_Orders);
                db.SaveChanges();
            }
        }
    }
}
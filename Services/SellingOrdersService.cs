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
    public class SellingOrdersService : ApiServiceAbstract
    {
        public Task<List<Selling_Orders>> GetSellingOrdersAsync()
        {
            return GetAsync<Selling_Orders>("api/SellingOrders");
        }

        public Task<Selling_Orders> GetSellingOrderAsync(int id)
        {
            return GetAsync<Selling_Orders>("api/SellingOrders", id);
        }

        public Task<List<Employees>> GetEmployeesAsync()
        {
            return GetAsync<Employees>("api/Employees");
        }

        public Task<List<Products>> GetProductsAsync()
        {
            return GetAsync<Products>("api/Products");
        }

        public Task CreateSellingOrder(Selling_Orders order)
        {
            return PostAsync("api/SellingOrders", order);
        }

        public Task EditSellingOrder(
            Selling_Orders order,
            int id)
        {
            return PutAsync(
                "api/SellingOrders",
                id,
                order);
        }

    }
}
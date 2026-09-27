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
    public abstract class ApiServiceAbstract
    {
        protected readonly HttpClient client;

        protected ApiServiceAbstract()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(
                    ConfigurationManager.AppSettings["ProductsApiUrl"])
            };
        }

        protected async Task<List<T>> GetAsync<T>(string endpoint)
        {
            var response = await client.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        protected async Task<T> GetAsync<T>(string endpoint, int id)
        {
            var response = await client.GetAsync($"{endpoint}/{id}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        protected async Task PostAsync<T>(string endpoint, T model)
        {
            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(endpoint, content);

            response.EnsureSuccessStatusCode();
        }

        protected async Task PutAsync<T>(string endpoint, int id, T model)
        {
            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(
                json,
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await client.PutAsync(
                $"{endpoint}/{id}",
                content);

            response.EnsureSuccessStatusCode();
        }
    }
}
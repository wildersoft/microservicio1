using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Search.Models;

namespace Search.Interfaces
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            var client = this.HttpClientFactory.CreateClient("customerService");
            var response = await client.GetAsync($"api/Customers/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Customer customer = JsonConvert.DeserializeObject<Customer>(result);
                return customer;
            }

            return null;
        }
    }
}

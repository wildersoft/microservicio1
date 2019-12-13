using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Search.Models;

namespace Search.Interfaces
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        public SalesService(IHttpClientFactory httpClientFactory)
        {
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = this.HttpClientFactory.CreateClient("saleService");
            var response = await client.GetAsync($"api/Sales/Customers/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<ICollection<Order>>(result);
                return orders;
            }

            return null;
        }
    }
}
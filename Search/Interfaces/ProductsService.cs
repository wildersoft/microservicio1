using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Search.Models;

namespace Search.Interfaces
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory HttpClientFactory;
        public ProductsService(IHttpClientFactory httpClientFactory)
        {
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<Product> GetAsync(string id)
        {
            var client = this.HttpClientFactory.CreateClient("productService");
            var response = await client.GetAsync($"api/Products/{id}");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                Product product = JsonConvert.DeserializeObject<Product>(result);
                return product;
            }

            return null;
        }
    }
}

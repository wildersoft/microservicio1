using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.Models;

namespace Products.DAL
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly List<Product> repo = new List<Product>();
        public ProductsProvider()
        {
            for (int x = 0; x<100; x++)
            {
                repo.Add(new Product() { Id = x.ToString(), Name = $"Product{x}" });
            }
        }

        public Task<Product> GetAsync(string id)
        {
            Product result = repo.FirstOrDefault(item => item.Id == id);
            
            return Task.FromResult(result);
        }
    }
}

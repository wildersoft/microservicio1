using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Products.Models;

namespace Products.DAL
{
    public interface IProductsProvider
    {
        Task<Product> GetAsync(string id);
    }
}
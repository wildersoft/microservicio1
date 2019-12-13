using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.DAL;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider ProductsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.ProductsProvider = productsProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await this.ProductsProvider.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Search.Interfaces;

namespace Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersService CustomersService;
        private readonly IProductsService ProductsService;
        private readonly ISalesService SalesService;

        public SearchController(ICustomersService customerService, IProductsService productsService, ISalesService salesService)
        {
            this.CustomersService = customerService;
            this.ProductsService = productsService;
            this.SalesService = salesService;
        }

        [HttpGet("Customers/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                return BadRequest();
            }

            try
            {
                var customer = await this.CustomersService.GetAsync(customerId);
                var sales = await this.SalesService.GetAsync(customerId);
                sales.ToList().ForEach(sale =>
                    {
                        sale.Items.ToList().ForEach(subItem =>
                        {
                            var product = this.ProductsService.GetAsync(subItem.ProductId);
                            subItem.Product = product.Result;
                        });
                    });

                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

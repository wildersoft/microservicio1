using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.DAL;
using Customers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerProvider CustomerProvider;
        public CustomersController(ICustomerProvider customerProvider)
        {
            this.CustomerProvider = customerProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await this.CustomerProvider.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(result);            
        }
    }
}

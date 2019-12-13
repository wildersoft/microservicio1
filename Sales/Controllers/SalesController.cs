using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.DAL;

namespace Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider SalesProvider;
        public SalesController(ISalesProvider salesProvider)
        {
            this.SalesProvider = salesProvider;
        }
        
        [HttpGet("Customers/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var result = await this.SalesProvider.GetAsync(customerId);

            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
        
    }
}

using Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.DAL
{
    public interface ICustomerProvider
    {
        Task<Customer> GetAsync(string id);
    }
}

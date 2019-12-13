using Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Interfaces
{
    public interface ICustomersService
    {
        Task<Customer> GetAsync(string id);
    }
}

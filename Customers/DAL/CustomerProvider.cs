using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Models;

namespace Customers.DAL
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly List<Customer> repo = new List<Customer>();
        public CustomerProvider()
        {
            repo.Add(new Customer() { id = "CL01", Name = "Juan" });
            repo.Add(new Customer() { id = "CL02", Name = "Luis" });
            repo.Add(new Customer() { id = "CL03", Name = "Camila" });
            repo.Add(new Customer() { id = "CL04", Name = "Maria" });
            repo.Add(new Customer() { id = "CL05", Name = "Miguel" });
        }

        public Task<Customer> GetAsync(string id)
        {
            var result =  repo.FirstOrDefault(item => item.id == id);
            return Task.FromResult(result);
        }
    }
}

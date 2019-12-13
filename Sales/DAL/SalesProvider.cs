using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales.Models;

namespace Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> repo = new List<Order>();
        public SalesProvider()
        {
            repo.Add(
                new Order() { CustomerId = "CL01", Id = "001", OrderDate = DateTime.Today.AddDays(-32),
                    Items = new List<OrderItem>()
                        {
                            new OrderItem() { OrderId = "001", Id = "01", Price = 40, ProductId = "1", Quantity = 4},
                            new OrderItem() { OrderId = "001", Id = "02", Price = 33, ProductId = "2", Quantity = 2}
                        }
                });

            repo.Add(
                new Order() { CustomerId = "CL02", Id = "002", OrderDate = DateTime.Today.AddDays(-22),
                    Items = new List<OrderItem>()
                        {
                            new OrderItem() { OrderId = "002", Id = "03", Price = 40, ProductId = "11", Quantity = 4},
                            new OrderItem() { OrderId = "002", Id = "04", Price = 33, ProductId = "22", Quantity = 2},
                            new OrderItem() { OrderId = "002", Id = "05", Price = 33, ProductId = "42", Quantity = 12}
                        }
                });

            repo.Add(
                new Order() { CustomerId = "CL03", Id = "003", OrderDate = DateTime.Today.AddDays(-18),
                        Items = new List<OrderItem>()
                        {
                            new OrderItem() { OrderId = "003", Id = "06", Price = 10, ProductId = "1", Quantity = 14},
                        }
                });
            
            repo.Add(
                new Order() { CustomerId = "CL04", Id = "004", OrderDate = DateTime.Today.AddDays(-12),
                    Items = new List<OrderItem>()
                        {
                            new OrderItem() { OrderId = "004", Id = "07", Price = 4, ProductId = "21", Quantity = 23},
                            new OrderItem() { OrderId = "004", Id = "08", Price = 13, ProductId = "6", Quantity = 42}
                        }
                });
            
            repo.Add(new Order() { CustomerId = "CL05", Id = "005", OrderDate = DateTime.Today.AddDays(-2) });
        }

        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var result = repo.Where(item => item.CustomerId == customerId).ToList();
            return Task.FromResult((ICollection<Order>)result);
        }
    }
}
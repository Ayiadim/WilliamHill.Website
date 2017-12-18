using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.Tests.Mocks
{
    public class MockCustomerRepository : IRepository<Customer>
    {

        List<Customer> customers;

        public MockCustomerRepository()
        {
            customers = new List<Customer>
            {
                new Customer { ID = 1, Name = "Dimitri" },
                new Customer { ID = 2, Name = "Del" },
                new Customer { ID = 3, Name = "Russel" }
            };
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Customer>>();
            tcs.SetResult(customers);
            return tcs.Task;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Interface;

using Repository.Entities;

namespace Repository.Interface
{
    public interface IRepository : IQueryableRepository
    {
        CustomerEntity GetCustomer(int customerId);
        IEnumerable<CustomerEntity> GetCustomers();

        CustomerEntity CreateCustomer(CustomerEntity customer);

        CustomerEntity FindCustomerByName(string customerName);

        void DeleteCustomer(int customerId);
    }
}

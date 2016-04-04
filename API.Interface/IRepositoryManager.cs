using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Model;

namespace API.Interface
{
    public interface IRepositoryManager
    {
        CustomerModel GetCustomer(int customerId);

        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel CreateCustomer(CustomerModel customer);

        CustomerModel FindCustomerByName(string customerName);

        void DeleteCustomer(int customerId);
    }
}

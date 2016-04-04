using Domain.Model;
using System.Collections.Generic;

namespace API.Interface
{
    public interface IDomain
    {
        CustomerModel GetCustomer(int customerId);

        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel CreateCustomer(CustomerModel customer);

        CustomerModel FindCustomerByName(string customerName);
        void DeleteCustomer(int customerId);
    }
}

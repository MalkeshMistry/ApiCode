using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Interface;

using Domain.Model;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IRepositoryProvider _repoProvider;

        public RepositoryManager(IRepositoryProvider repoProvider)
        {
            _repoProvider = repoProvider;
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return _repoProvider.GetCustomer(customerId);
        }

        public CustomerModel CreateCustomer(CustomerModel customer)
        {
            return _repoProvider.CreateCustomer(customer);
        }

        public CustomerModel FindCustomerByName(string customerName)
        {
            return _repoProvider.FindCustomerByName(customerName);
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _repoProvider.GetCustomers();
        }

        public void DeleteCustomer(int customerId)
        {
            _repoProvider.DeleteCustomer(customerId);
        }
    }
}

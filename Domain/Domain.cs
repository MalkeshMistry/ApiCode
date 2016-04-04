using System;
using System.Collections.Generic;
using API.Interface;

using Domain.Model;

namespace Domain
{
    public class Domain : IDomain
    {
        private readonly IRepositoryManager _repoManager;

        public Domain (IRepositoryManager repoManager)
        {
            _repoManager = repoManager;
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return _repoManager.GetCustomer(customerId);
        }

        public CustomerModel CreateCustomer(CustomerModel customer)
        {
           // throw new NotImplementedException();
            return _repoManager.CreateCustomer(customer);
        }

        public CustomerModel FindCustomerByName(string customerName)
        {
            return _repoManager.FindCustomerByName(customerName);
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _repoManager.GetCustomers();
        }

        public void DeleteCustomer(int customerId)
        {
            _repoManager.DeleteCustomer(customerId);
        }
    }
}

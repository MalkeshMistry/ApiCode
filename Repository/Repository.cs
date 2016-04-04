using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Entities;
using Repository.Interface;

namespace Repository
{
    public class Repository : IRepository
    {
        private readonly IRepositoryContext _context;

        public Repository(IRepositoryContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this._context = context;
        }

        public CustomerEntity GetCustomer(int customerId)
        {
            return _context.DbSet<CustomerEntity>().FirstOrDefault(f => f.CustomerId == customerId);
        }

        public CustomerEntity CreateCustomer(CustomerEntity customer)
        {
            _context.DbSet<CustomerEntity>().AddOrUpdate(customer);
            return customer;
        }

        public CustomerEntity FindCustomerByName(string customerName)
        {
            return _context.DbSet<CustomerEntity>().FirstOrDefault(f => f.CustomerName == customerName); 
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return _context.DbSet<CustomerEntity>();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.DbSet<CustomerEntity>().FirstOrDefault(f => f.CustomerId == customerId);
            if(customer!=null)
            _context.DbSet<CustomerEntity>().Remove(customer);
        }
    }
}

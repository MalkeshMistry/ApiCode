using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Interface;

using Autofac.Features.Indexed;

using Domain.Model;

using Repository.Domain;
using Repository.Entities;
using Repository.Interface;

namespace Repository
{
    public class RepositoryProvider : RepositoryProviderBase, IRepositoryProvider
    {
        private readonly Func<IRepositoryContext> _contextFactory;
        private readonly IIndex<Type, Func<IRepositoryContext, IQueryableRepository>> _repositoryFactory;
        private readonly IMapper<CustomerEntity, CustomerModel> _entityMapper;

        public RepositoryProvider(Func<IRepositoryContext> contextFactory, IMapper<CustomerEntity, CustomerModel> entityMapper, IIndex<Type, Func<IRepositoryContext, IQueryableRepository>> repositoryFactory)
        {
            _contextFactory = contextFactory;
            _entityMapper = entityMapper;
            _repositoryFactory = repositoryFactory;
        }
        protected override IRepositoryContext Context()
        {
            return _contextFactory();
        }

        public CustomerModel GetCustomer(int customerId)
        {
            using (var ctx = this.Context())
            {
                var repository = (IRepository)_repositoryFactory[typeof(IRepository)](ctx);
                return _entityMapper.Map(repository.GetCustomer(customerId));
            }
        }

        public CustomerModel CreateCustomer(CustomerModel customer)
        {
            using (var ctx = this.Context())
            {
                var repository = (IRepository)_repositoryFactory[typeof(IRepository)](ctx);
                var result = repository.CreateCustomer(_entityMapper.Map(customer));
                ctx.SaveChanges();
                return _entityMapper.Map(result);
            }
        }

        public CustomerModel FindCustomerByName(string customerName)
        {
            using (var ctx = this.Context())
            {
                var repository = (IRepository)_repositoryFactory[typeof(IRepository)](ctx);
                return _entityMapper.Map(repository.FindCustomerByName(customerName));
            }
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            using (var ctx = this.Context())
            {
                var repository = (IRepository)_repositoryFactory[typeof(IRepository)](ctx);
                return _entityMapper.Map(repository.GetCustomers());
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var ctx = this.Context())
            {
                var repository = (IRepository)_repositoryFactory[typeof(IRepository)](ctx);
                repository.DeleteCustomer(customerId);
                ctx.SaveChanges();              
            }
        }
    }
}

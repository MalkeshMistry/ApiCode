using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MapperProject;

using Repository.Entities;
using Domain.Model;

namespace Repository.Mappers
{
    public class CustomerEntityModelMapper : Mapper<CustomerEntity, CustomerModel>
    {
        public override CustomerEntity Map(CustomerModel t)
        {
            return new CustomerEntity
            {
                CustomerId = t.CustomerId,
                CustomerName = t.CustomerName,
                CustomerAddress = t.CustomerAddress,
                CustomerContactNumner = t.CustomerContactNumner
            };
        }

        public override CustomerModel Map(CustomerEntity t)
        {
            return new CustomerModel
            {
                CustomerId = t.CustomerId,
                CustomerName = t.CustomerName,
                CustomerAddress = t.CustomerAddress,
                CustomerContactNumner = t.CustomerContactNumner
            };
        }
    }
}
